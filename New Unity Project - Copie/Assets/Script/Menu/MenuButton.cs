using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text theText;

    public Color hoverColor = Color.red;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white;
    }
}
