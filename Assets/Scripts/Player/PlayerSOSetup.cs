using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class PlayerSOSetup : ScriptableObject
{
    public Animator player;

    [Header("Animation")]
    
    public float scaleDuration = .2f;
    public Ease ease = Ease.OutBack;


}
