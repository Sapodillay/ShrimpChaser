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
        closestInteractable = (Interactable)Helper.GetClosestGameObject(interactablesInRange, gameObject.transform.position);
        if (closestInteractable == null ) return;
        Debug.DrawLine(gameObject.transform.position, closestInteractable.transform.position);
    }


    /// <summary>
    /// used in other classes to retrieve the closest interactable
    /// </summary>
    /// <returns></returns>
    public Interactable GetClosestInteractable()
    {
        return (Interactable)Helper.GetClosestGameObject(interactablesInRange, gameObject.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //only allow triggers
        if (!collision.collider.isTrigger) return;
        if (!collision.gameObject.TryGetComponent<Interactable>(out Interactable interactable)) return;
        interactablesInRange.Add(interactable);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //only allow triggers
        if (!collision.collider.isTrigger) return;
        if (!collision.gameObject.TryGetComponent<Interactable>(out Interactable interactable)) return;
        interactablesInRange.Remove(interactable);
    }





    private void Awake()
    {
        instance = this;
    }






}
