using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("Setup")]
    public PlayerSOSetup playerSOSetup;


    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;
    

    public bool invencible = true;
   
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;
    private bool _isFlying;

    [Header("Animation")]
    public AnimatorManager animatorManager;
    [SerializeField] private BounceHelper _bounceHelper;

    [Header("VFX")]
    public ParticleSystem vfxDeath;

    [Header("Limits")]
    public Vector2 limitVector = new Vector2(-4, 4);

    [Header("Sounds")]
    public AudioSource winAudio;
    public AudioSource loseAudio;

    private float targetScale;

    public void SetTargetScale(float targetScale)
    {
        this.targetScale = targetScale;
    }

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

        StartCoroutine(PlayerScaleStart());
    }

    public void Bounce()
    {
        if(_bounceHelper !=null)
            _bounceHelper.Bounce(targetScale);
    }

    IEnumerator PlayerScaleStart()
    {
        transform.localScale = Vector3.zero;

        yield return new WaitForSeconds(playerSOSetup.scaleShowDuration);

        float time = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 targetScale = Vector3.one;

        while (time < playerSOSetup.scaleShowDuration)
        {
            time += Time.deltaTime;
            float t = time / playerSOSetup.scaleShowDuration;
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }

    public void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if (_pos.x < limitVector.x) _pos.x = limitVector.x;
        else if (_pos.x > limitVector.y) _pos.x = limitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if(!invencible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD);
                if (vfxDeath != null) vfxDeath.Play();
                loseAudio.Play();
               
            }

        }
    }
    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            EndGame();

            winAudio.Play();

        }
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible (bool a = true)
    {
        invencible = a;
        
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
        _isFlying = true;
        animatorManager.PlaySetBool(AnimatorManager.AnimationType.FLY, true);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, 1f);
        _isFlying = false;
        animatorManager.PlaySetBool(AnimatorManager.AnimationType.FLY, false);
    }

    public bool IsFlying()
    {
        return _isFlying;
    }
}
