using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    [SerializeField] Animator _animator;


    [SerializeField] string IDLE_STATE;
    [SerializeField] string LEFT_STATE;
    [SerializeField] string RIGHT_STATE;
    [SerializeField] string UP_STATE;
    [SerializeField] string DOWN_STATE;

    string currentState;




    public void ProcessMovements(Vector2 movementVector)
    { 
        if (movementVector.magnitude == 0)
        {
            ChangeAnimationState(IDLE_STATE);
            return;
        }
        if (movementVector.x > 0)
        {
            ChangeAnimationState(RIGHT_STATE);
            return;
        }
        if (movementVector.x < 0)
        {
            ChangeAnimationState(LEFT_STATE);
            return;
        }
        if (movementVector.y > 0)
        {
            ChangeAnimationState(UP_STATE);
            return;
        }
        if (movementVector.y < 0)
        {
            ChangeAnimationState(DOWN_STATE);
            return;
        }
    }



    void ChangeAnimationState(string state)
    {
        //State doesn't change, prevent it from resetting it
        if (currentState == state) return;

        currentState = state;
        _animator.Play(state);



    }



}
