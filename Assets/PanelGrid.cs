using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelGrid: PanelGridElement
{
    private List<PanelGridElement> gridElements;

    private void Awake()
    {
        gridElements = new List<PanelGridElement>();

        foreach (Transform child in transform)
        {
            PanelGridElement element;
            if(child.TryGetComponent(out element))
            {
                gridElements.Add(element);
            }
        }
    }

    
    public override void Activate()
    {
        gameObject.SetActive(true);

        foreach (var element in gridElements)
        {
            if(element != this) element.Activate();
        }

        base.Activate();
    }

    public override void Deactivate()
    {
        foreach (var element in gridElements)
        {
            if (element != this) element.Deactivate();
            
        }

        gameObject.SetActive(false);

        base.Deactivate();
    }
}