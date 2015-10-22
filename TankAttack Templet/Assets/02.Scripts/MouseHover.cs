using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static MouseHover instance = null;
    public bool isUIHover = false;

	void Awake()
    {
        instance = this;
    }

    public void OnPointerEnter( PointerEventData eventData )
    {
        isUIHover = true;
        Debug.Log("hover");
    }

    public void OnPointerExit( PointerEventData eventData )
    {
        isUIHover = false;
        Debug.Log("Unhover");
    }
}
