using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI m_TextMeshPro;



    private void OnEnable()
    {
        Debug.Log(Game.Instance);
        Debug.Log("Waterpumps left: " + Game.Instance.pumpsLeft.ToString());
        m_TextMeshPro.text = "Waterpumps left: " + Game.Instance.pumpsLeft.ToString();        
    }

    private void FixedUpdate()
    {
        m_TextMeshPro.text = "Waterpumps left: " + Game.Instance.pumpsLeft.ToString();
    }



}
