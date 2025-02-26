using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NewGameText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;

    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
    }
}
