using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private RectTransform rect;
    private Vector3 startPos;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rect.DOScale(Vector3.one * 1.4f, 0.3f);
        startPos = rect.transform.position;
        GetComponent<CheckItem>().SaveStartPosition();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rect.DOScale(Vector3.one * 1.2f, 0.3f);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rect.transform.position = Input.mousePosition;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.DOScale(Vector3.one * 1.2f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.DOScale(Vector3.one, 0.3f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerEnter.GetComponent<InventorySlot>() == false)
        {
            rect.transform.position = startPos;
        }
    }
}
