using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButtonAnimated : TabButton
{

    public enum TabButtonAnimationType
    {
        MoveUp,
        MoveRight,
        MoveDown,
        MoveLeft
    }
    public TabButtonAnimationType tabButtonAnimationType;
    public float animationMovement = 20f;
    public float activationDelay = 0.1f;
    private RectTransform rectTransform;
    //public override void Start()
    //{
    //    base.Start();
    //    rectTransform = GetComponent<RectTransform>();
    //    onTabSelected.AddListener(SelectAnimation);
    //    onTabDeselected.AddListener(DeselectAnimation);
    //    onActivate.AddListener(StartAnimation);
    //}

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        onTabSelected.AddListener(SelectAnimation);
        onTabDeselected.AddListener(DeselectAnimation);
        onActivate.AddListener(StartAnimation);
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
            LeanTween.moveY(gameObject, transform.position.y + animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveRight)
        {
            LeanTween.moveX(gameObject, transform.position.x + animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveDown)
        {
            LeanTween.moveY(gameObject, transform.position.y - animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveLeft)
        {
            LeanTween.moveX(gameObject, transform.position.x - animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
    }
    public void DeselectAnimation()
    {
        if (tabButtonAnimationType == TabButtonAnimationType.MoveUp)
        {
            LeanTween.moveY(gameObject, transform.position.y - animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveRight)
        {
            LeanTween.moveX(gameObject, transform.position.x - animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveDown)
        {
            LeanTween.moveY(gameObject, transform.position.y + animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
        if (tabButtonAnimationType == TabButtonAnimationType.MoveLeft)
        {
            LeanTween.moveX(gameObject, transform.position.x + animationMovement, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
        }
    }
}
