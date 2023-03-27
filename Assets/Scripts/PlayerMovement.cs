using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rb;

    [SerializeField] AnimationHandler _animationHandler;


    private void FixedUpdate()
    {
        ProcessMovements();
    }

    void ProcessMovements()
    {
        Vector2 movementVector = InputHandler.instance.GetMovementVector();
        _rb.velocity = movementVector * _moveSpeed;

        _animationHandler.ProcessMovements(movementVector);

    }





}
