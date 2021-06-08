using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPager : PanelGridElement
{
    public TabGroup tabGroup;

    [ContextMenu("Activate")]
    public override void Activate()
    {
        gameObject.SetActive(true);

        base.Activate();
        tabGroup.InitializeSelected();
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
        base.Deactivate();
    }
}
