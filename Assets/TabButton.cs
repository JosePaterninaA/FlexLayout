using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public bool selectedOnStart = false;
    public Image background;
    public int panelGridAttachedId = 0;
    public float activationDelay = 0.1f;
    public bool selectable = false;

    [Header("Events")]
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;
    public UnityEvent onTabStarted;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(selectable) tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selectable) tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selectable) tabGroup.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        onTabSelected.AddListener(SelectAnimation);
        onTabDeselected.AddListener(DeselectAnimation);
        onTabStarted.AddListener(StartAnimation);
        tabGroup.Subscribe(this);
    }

    public void StartAnim()
    {
        if (onTabStarted != null)
        {
            onTabStarted.Invoke();
        }
    }

    public void Select()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }

    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }
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
        LeanTween.moveLocalY(gameObject, 20f, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);

    }
    public void DeselectAnimation()
    {
        LeanTween.moveLocalY(gameObject, 0, 0.1f)
            .setEase(LeanTweenType.easeInOutBack);
    }
}
