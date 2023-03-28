using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    
    public static InteractionHandler instance;


    /// <summary>
    /// All interactables currently in the level.
    /// </summary>
    public List<Interactable> interactables;
    public List<Interactable> interactablesInRange;


    public Interactable closestInteractable;


    private void FixedUpdate()
    {
        SetClosestInteractable();
    }



    /// <summary>
    /// Used to visualize the closest interactable in realtime
    /// </summary>
    void SetClosestInteractable()
    {
        if (interactablesInRange.Count == 0) return;

        //Pure cast
        Interactable newClosestinteract = (Interactable)Helper.GetClosestGameObject(interactablesInRange, gameObject.transform.position);
        if (closestInteractable == newClosestinteract) return;

        //Change back to white.
        if (closestInteractable!= null)
        {
            closestInteractable.ChangeColor(Color.white);
        }

        closestInteractable = newClosestinteract;
        newClosestinteract.ChangeColor(Color.red);
    }


    /// <summary>
    /// used in other classes to retrieve the closest interactable
    /// </summary>
    /// <returns></returns>
    public Interactable GetClosestInteractable()
    {
        return (Interactable)Helper.GetClosestGameObject(interactablesInRange, gameObject.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Interactable>(out Interactable interactable)) return;
        interactablesInRange.Add(interactable);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //only allow triggers
        if (!collision.gameObject.TryGetComponent<Interactable>(out Interactable interactable)) return;
        interactablesInRange.Remove(interactable);
        if (interactable == closestInteractable)
        {
            closestInteractable = null;
            interactable.ChangeColor(Color.white);

        }

    }

    internal void onInteraction()
    {
        closestInteractable.onInteraction();
    }



    private void Awake()
    {
        instance = this;
    }
}
