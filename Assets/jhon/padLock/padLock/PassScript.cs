using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassScript : MonoBehaviour, IPointerClickHandler
{
    //script de pass
    private int value = 0;
    CheckPassword parentScript;
    bool rotating = false;
    float rotateValue = 36f;

    private void Awake()
    {
        parentScript = GetComponentInParent<CheckPassword>();
    }

    private void Update()
    {
        
        if (rotating)
        {
            if (rotateValue > 0)
            {
                rotateValue--;
                transform.Rotate(Vector3.forward, 1);
            }

            else
            {
                rotateValue = 36;
                rotating = false;
            }
        }
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!rotating)
        {
            if (value < 9)
                value++;
            else value = 0;
            rotating = true;

            if (parentScript.checkPass())
            {
                Debug.Log("Opened");
                Invoke("end", 0.65f);
                //parentScript.complete();
            }
        }
    }
    void end()
    {
        parentScript.complete();
    }

    public int getValue()
    {
        return this.value;
    }

}
