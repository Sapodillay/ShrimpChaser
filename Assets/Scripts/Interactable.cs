using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{

    [SerializeField] Collider2D _interactionCollider;


    static readonly int shPropColor = Shader.PropertyToID("_Color");

    MaterialPropertyBlock _materialPropertyBlock;
    public MaterialPropertyBlock materialPropertyBlock
    {
        get
        {
            if (_materialPropertyBlock == null)
                _materialPropertyBlock = new MaterialPropertyBlock();
            return _materialPropertyBlock;
        }
    }



    private void OnEnable()
    {
        InteractionHandler.instance.interactables.Add(this);
    }
    private void OnDisable()
    {
        InteractionHandler.instance.interactables.Remove(this);
    }


    public void ChangeColor(Color color)
    {
        SpriteRenderer rnd;
        if (!TryGetComponent<SpriteRenderer>(out rnd)) return;
        materialPropertyBlock.SetColor(shPropColor, color);
        rnd.SetPropertyBlock(materialPropertyBlock);
    }




}
