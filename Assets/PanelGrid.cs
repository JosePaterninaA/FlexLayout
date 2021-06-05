using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelGrid: PanelGridElement
{
    public int id;
    private PanelGridElement[] gridElements;

    private void Awake()
    {
        gridElements = GetComponentsInChildren<PanelGridElement>();
    }

    
    public override void Activate()
    {
        gameObject.SetActive(true);
        foreach (var element in gridElements)
        {
            if(element != this) element.Activate();
        }
        if (onActivate != null)
        {
            onActivate.Invoke();
        }
    }

    public override void Deactivate()
    {
        foreach (var element in gridElements)
        {
            if (element != this) element.Deactivate();
        }
        gameObject.SetActive(false);
        if (onDeactivate != null)
        {
            onDeactivate.Invoke();
        }
    }
}