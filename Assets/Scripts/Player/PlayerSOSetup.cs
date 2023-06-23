using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class PlayerSOSetup : ScriptableObject
{
    public Animator player;

    [Header("Animation ShowIn")]
    
    public float scaleShowDuration = .2f;
    public Ease easeShow = Ease.OutBack;

    /*[Header("Animation Bounce")]
    public float scaleBounceDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease easeBounce = Ease.OutBack;

    [Header("PowerUP Scale")]
    public float invencibleScale = 2f;
    public float speedScale = 0.5f;*/
}
