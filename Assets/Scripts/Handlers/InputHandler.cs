using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    
    public static InputHandler instance
    {
        get; private set;
    }

    Vector2 _movementVector = new Vector2(0,0);


    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        ProcessInputs();
    }


    /// <summary>
    /// returns normalized vector based on movement inputs
    /// </summary>
    void ProcessInputs()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Vertical");
        _movementVector = new Vector2(_x, _y).normalized;


        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractionHandler.instance.onInteraction();
        }


    }

    public Vector2 GetMovementVector()
    {
        return _movementVector;
    }



}
