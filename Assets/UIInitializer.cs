using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    public PanelPager mainPager;
    // Start is called before the first frame update
    void Start()
    {
        mainPager.Activate();
    }

}
