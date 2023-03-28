using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{


    public override void onInteraction()
    {
        Debug.Log("Pickup code");
        base.Recylce();
    }



}
