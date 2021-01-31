using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindItems : MonoBehaviour
{
    public static FindItems judge;
    public Sprite[] sprites;

    private float alpha;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        judge = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mousePos;
        if(alpha > 0)
        {
            alpha -= Time.deltaTime * 0.5f;
        }
        GetComponent<Image>().color = new Color(255, 255, 255, alpha);
    }

    public void GetMousePosition ( bool isRight)
    {
        if(isRight)
            gameObject.GetComponent<Image>().sprite = sprites[0];
        else
            gameObject.GetComponent<Image>().sprite = sprites[1];

        mousePos = Input.mousePosition;
        alpha = 1;
    }
}
