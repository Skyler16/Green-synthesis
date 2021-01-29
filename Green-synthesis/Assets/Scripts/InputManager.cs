using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public ObjectList objList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                Slot slot = hit.transform.gameObject.GetComponent<Slot>();
                GameObject obj = objList.CompositePrefabs[0];
                CompositePanel.Get.PlaceObject(slot, obj);
            }
        }
    }
}
