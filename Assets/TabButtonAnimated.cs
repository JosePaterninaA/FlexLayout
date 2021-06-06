using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButtonAnimated : TabButton
{

    public enum TabButtonAnimationType
    {
        MoveUp,
        MoveRight
    }
    public TabButtonAnimationType tabButtonAnimationType;
    public float animationMovement = 20f;
    public float activationDelay = 0.1f;
    public override void Start()
    {
        base.Start();
        onTabSelected.AddListener(SelectAnimation);
        onTabDeselected.AddListener(DeselectAnimation);
        onTabStarted.AddListener(StartAnimation);
    }

    public void StartAnimation()
    {
        //transform.localScale = Vector3.zero;
        //LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 10f);
        //    .setEase(LeanTweenType.easeInExpo)
        //    .setDelay(activationDelay)
        //    .setOnComplete(()=> { selectable = true; });
        transform.RotateAround(transform.position, Vector3.up, -90f);
        LeanTween.rotateAround(gameObject, Vector3.up, 90, 0.2f).setDelay(activationDelay);
        selectable = true;
    }

    public void SelectAnimation()
    {
        if (tabButtonAnimationType == TabButtonAnimationType.MoveUp)
        {
            LeanTween.moveLocalY(gameObject, animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveRight)
        {
            LeanTween.moveLocalX(gameObject, animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
            Debug.Log("right");
        }

    }
    public void DeselectAnimation()
    {
        if (tabButtonAnimationType == TabButtonAnimationType.MoveUp)
        {
            LeanTween.moveLocalY(gameObject, 0, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveRight)
        {
            LeanTween.moveLocalX(gameObject, 0, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
    }
}
