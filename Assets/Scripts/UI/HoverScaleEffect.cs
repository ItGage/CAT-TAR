using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float hoverScaleMultiplier;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * hoverScaleMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
}