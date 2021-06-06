using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGridElementAnimated : PanelGridElement
{
    public float activationDelay = 0.1f;

    private void Start()
    {
        onActivate.AddListener(ActivateAnimation);
        onDeactivate.AddListener(DeactivateAnimation);
    }

    public void ActivateAnimation()
    {
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.2f).setDelay(activationDelay);
    }

    public void DeactivateAnimation()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.1f);
    }
}
