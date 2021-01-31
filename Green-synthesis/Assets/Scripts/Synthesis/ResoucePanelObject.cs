using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoucePanelObject : MonoBehaviour
{
    public int objId;

    bool isPicking = false;

    private void Update()
    {
        if (!isPicking)
        {
            transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime * ResourcePanel.Get.moveSpeed;
        }
        else
        {
           Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition)
                                - transform.position;
           transform.Translate(mousePos);
        }
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        ++Game.Get.lostScore;
    }

    public void Pickup()
    {
        isPicking = true;
    }
}
