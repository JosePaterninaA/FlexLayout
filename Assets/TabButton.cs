using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{


    [HideInInspector] public Image background;
    public TabGroup tabGroup;
    public int panelGridAttachedId = 0;
    public bool selectable = true;
    public bool selectedOnStart = false;

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
    public virtual void Start()
    {
        background = GetComponent<Image>();
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
            selectable = false;
            onTabSelected.Invoke();
        }
    }

    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            selectable = true;
            onTabDeselected.Invoke();
        }
    }

    
}
