using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickLighten : MonoBehaviour, IPointerClickHandler
{
    ColorPuzzle parentScript;

    private void Start()
    {
        parentScript = GetComponentInParent<ColorPuzzle>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clickado");
        if (!parentScript.isUsable()) return;

        parentScript.lightUp(gameObject);
        parentScript.addUserInput(gameObject);
    }
}
