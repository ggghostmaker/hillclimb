using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarPedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultGraphic;
    public Sprite pressedGraphic;

    public Image graphicComponent;

    public UnityEvent onMouse;

    bool isMouseDown;

    void Start()
    {
        graphicComponent.sprite = defaultGraphic;
    }

    void Update()
    {
        if (isMouseDown)
        {
            onMouse.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
        graphicComponent.sprite = pressedGraphic;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false;
        graphicComponent.sprite = defaultGraphic;
    }
}
