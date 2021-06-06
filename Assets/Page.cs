using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : PanelGridElement
{
    private void Awake()
    {
        onActivate.AddListener(ActivatePage);
        onDeactivate.AddListener(DeactivatePage);
    }

    void ActivatePage()
    {
        gameObject.SetActive(true);
    }

    void DeactivatePage()
    {
        gameObject.SetActive(false);
    }
}
