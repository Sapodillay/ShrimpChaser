using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{

    [SerializeField] Collider2D _interactionCollider;




    private void OnEnable()
    {
        InteractionHandler.instance.interactables.Add(this);
    }
    private void OnDisable()
    {
        InteractionHandler.instance.interactables.Remove(this);
    }


}
