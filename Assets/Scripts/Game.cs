using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    public static Game Instance { get; private set; }

    public int pumpsLeft = 5;


    public void Awake()
    {
        Instance = this;
    }



    public void onPumpComplete()
    {
        if (pumpsLeft == 1)
        {
            //Open the exit;
            ExitOpen();
            return;
        }
        pumpsLeft--;
    }

    public void ExitOpen()
    {

    }


}
