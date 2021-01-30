using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    public ScrollRect scrollerRect;
    public float moveSpeed = 0.5f; 

    float horposition = 0;
    float distance = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollerRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ((IEndDragHandler)scrollerRect).OnEndDrag(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ((IBeginDragHandler)scrollerRect).OnBeginDrag(eventData);
    }
}
