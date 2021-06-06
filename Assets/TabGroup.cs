using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public PanelGroup panelGroup;

    public Color idle;
    public Color selected;
    public Color enter;
    
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
        if (button.selectedOnStart)
        {
            OnTabSelected(button);
        }
        else
        {
            button.StartAnim();
        }

    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            button.background.color = enter;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if(selectedTab!= null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        panelGroup.currentPanelGridId = button.panelGridAttachedId;
        panelGroup.ShowCurrentPanelGrid();
        ResetTabs();
        button.background.color = selected;
    }

    public void ResetTabs()
    {
        foreach (var button in tabButtons)
        {
            if (button != null && button == selectedTab) { continue; }
            button.background.color = idle;
        }
    }
}
