using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    public PanelPager mainPager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    public IEnumerator Initialize()
    {
        yield return new WaitForSeconds(0.1f);
        mainPager.Activate();

    }
}
