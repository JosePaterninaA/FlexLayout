using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public TabButton selectedOnStart;
    public PageGroup pageGroup;

    public Color idle;
    public Color selected;
    public Color enter;

    private bool initialized = false;
    
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);

        if (button.selectedOnStart)
        {
            selectedOnStart = button;
            selectedTab = button;
        }
    }

    public void InitializeSelected()
    {
        if (selectedOnStart != null)
        {
            StartCoroutine(InitializeWithDelay(selectedOnStart));
            return;
        }
        //OnTabSelected(selectedOnStart);

    }

    private IEnumerator InitializeWithDelay(TabButton button)
    {
        yield return new WaitForSeconds(0.001f);
        OnTabSelected(button);
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
        if(selectedTab!= null  && initialized)
        {
            selectedTab.Deselect();
        }

        if (selectedTab != null &&  selectedTab.selectedOnStart)
        {
            initialized = true;
        }

        selectedTab = button;
        selectedTab.Select();
        pageGroup.currentPanelGridId = button.panelGridAttachedId;
        pageGroup.ShowCurrentPanelGrid();
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
