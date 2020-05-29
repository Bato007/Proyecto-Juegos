using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.white;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
