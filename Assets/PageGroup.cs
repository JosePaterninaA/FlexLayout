using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGroup : PanelGridElement
{
    public PanelGridElement[] pages;
    public int currentPanelGridId = 0;

    public void ShowCurrentPanelGrid()
    {
        for(int i = 0; i < pages.Length; i++)
        {
            if(currentPanelGridId == pages[i].id)
            {
                pages[i].Activate();
            }
            else
            {
                pages[i].Deactivate();
            }
        }
    }
}
