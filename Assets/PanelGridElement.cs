using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelGridElement : MonoBehaviour
{
    public float activationDelay = 0.1f;
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    public virtual void Activate()
    {
        Debug.Log($"{gameObject.name} activated");
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.2f).setDelay(activationDelay);
        if (onActivate != null)
        {
            onActivate.Invoke();
        }
    }

    public virtual void Deactivate()
    {
        LeanTween.scale(gameObject,Vector3.zero, 0.1f);
        if (onDeactivate != null)
        {
            onDeactivate.Invoke();
        }
    }
}
