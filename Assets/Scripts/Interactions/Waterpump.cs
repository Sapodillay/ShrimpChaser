using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterpump : Interactable
{
    public override void onInteraction()
    {
        CompleteGenerator();
    }


    public void CompleteGenerator()
    {
        Game.Instance.onPumpComplete();
    }


}
