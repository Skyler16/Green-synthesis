using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    public float moveSpeed = 5f;

    private ScrollRect scrollerRect;
    private bool isdraging;

    float horposition = 0;
    float startPos = 0;
    float distance = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollerRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isdraging)
        {
            //scrollerRect.horizontalNormalizedPosition = Mathf.Lerp(scrollerRect.horizontalNormalizedPosition, scrollerRect.horizontalNormalizedPosition + distance, Time.deltaTime * moveSpeed) ;
        }
        Debug.Log(scrollerRect.horizontalNormalizedPosition);
        //Debug.Log("distance:" + distance);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        distance = Input.mousePosition.y - startPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isdraging = true;
        startPos = Input.mousePosition.y;
    }
}
