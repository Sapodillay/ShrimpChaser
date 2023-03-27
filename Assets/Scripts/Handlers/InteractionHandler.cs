using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    
    public static InteractionHandler instance;


    /// <summary>
    /// All interactables currently in the level.
    /// </summary>
    public List<Interactable> interactables;

    public Interactable closestInteractable;


    private void FixedUpdate()
    {
        //Pure cast
        closestInteractable = (Interactable)Helper.GetClosestGameObject(interactables, gameObject.transform.position);
        Debug.DrawLine(gameObject.transform.position, closestInteractable.transform.position);
    }




    private void Awake()
    {
        instance = this;
    }






}
