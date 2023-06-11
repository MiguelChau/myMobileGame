using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD,
        JUMP,
        INVENCIBLE,
        FLY
    }
    public void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach(var animation in animatorSetups)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    public void PlaySetBool(AnimationType type, bool value)
    {
        for(int i = 0; i < animatorSetups.Count; ++i)
            if(animatorSetups[i].type == type)
            {
                animator.SetBool(animatorSetups[i].trigger, value);
            }
    }
        
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Play(AnimationType.RUN);
        }
        else if (Input.GetMouseButtonDown(2))
        {
            Play(AnimationType.DEAD);
        }
        else if (Input.GetMouseButtonDown(3))
        {
            Play(AnimationType.IDLE);
        } 
        else if (Input.GetMouseButtonDown(4))
        {
            Play(AnimationType.JUMP);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.INVENCIBLE);
        }

    }
}
[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
