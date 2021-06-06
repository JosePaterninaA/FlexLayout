using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelGridElement : MonoBehaviour
{
    public int id;

    [Header("Events")]
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    public virtual void Activate()
    {
        if (onActivate != null)
        {
            onActivate.Invoke();
        }
    }

    public virtual void Deactivate()
    {
        if (onDeactivate != null)
        {
            onDeactivate.Invoke();
        }
    }
}
