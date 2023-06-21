using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;
    public List<LevelPieceBaseSetupSO> levelPieceBaseSetupsSO;

    public float timeBetweenPieces;

    [SerializeField] private int _index;
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetupSO _currentSetup;

    [Header("Animation")]
    public float scaleDuration;
    public float scaleTimeBetweenPieces;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        CreateLevelPieces();
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPieces()
    {
        CleanPieces();

        if(_currentSetup != null)
        {
            _index++;

            if(_index >= levelPieceBaseSetupsSO.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentSetup = levelPieceBaseSetupsSO[_index];

        

        for(int i = 0; i <_currentSetup.piecesNumberStart; i++)
        {
            CreatePieces(_currentSetup.levelPiecesStart);
        } 
        
        for(int i = 0; i <_currentSetup.piecesNumber; i++)
        {
            CreatePieces(_currentSetup.levelPieces);
        }    
        
        for(int i = 0; i <_currentSetup.piecesNumberEnd; i++)
        {
            CreatePieces(_currentSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currentSetup.artType);

        StartCoroutine(ScalePiecesOnStart());

    }

    IEnumerator ScalePiecesOnStart()
    {
        foreach( var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;

        for(int i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void CreatePieces(List<LevelPieceBase> list)
    {
        if (list.Count > 0)
        {
            var piece = list[Random.Range(0, list.Count)];
            var spawnedPiece = Instantiate(piece, container);

            if (_spawnedPieces.Count > 0)
            {
                var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

                spawnedPiece.transform.position = lastPiece.endPiece.position;
            }
            else
            {
                spawnedPiece.transform.localPosition = Vector3.zero;
            }

            foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
            {
                p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
            }

            _spawnedPieces.Add(spawnedPiece);
        }
    }

    private void CleanPieces()
    {
        for(int i = _spawnedPieces.Count -1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CreateLevelPieces();
        }
    }
}
