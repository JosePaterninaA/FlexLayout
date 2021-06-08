using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    //public PanelPager mainPager;
    public PanelGridElement m_root;
    private bool m_activated = false;
    private bool m_canSwitch = true;
    private float m_activationDelay = 1;
    private float m_activationTime;

    // Start is called before the first frame update
    void Start()
    {
        m_root.Deactivate();
    }

    //public IEnumerator Initialize()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    mainPager.Activate();

    //}

    private void Update()
    {
        if (Time.time > m_activationTime)
        {
            m_activationTime = Time.time + m_activationDelay;
            m_canSwitch = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !m_activated && m_canSwitch)
        {
            m_root.Activate();
            m_activated = true;
            m_canSwitch = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && m_activated && m_canSwitch)
        {
            m_root.Deactivate();
            m_activated = false;
            m_canSwitch = false;
        }
    }
}
