using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoucePanelObject : MonoBehaviour
{
    public int objId;

    private void Update()
    {
        transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime * ResourcePanel.Get.moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        ++Game.Get.lostScore;
    }

    public void Pickup()
    {
        Destroy(this.gameObject);
    }
}
