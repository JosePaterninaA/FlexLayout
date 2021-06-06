using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public PanelGridElement[] panelGrids;
    public int currentPanelGridId = 0;

    public void ShowCurrentPanelGrid()
    {
        for(int i = 0; i < panelGrids.Length; i++)
        {
            if(currentPanelGridId == panelGrids[i].id)
            {
                panelGrids[i].Activate();
            }
            else
            {
                panelGrids[i].Deactivate();
            }
        }
    }
}
