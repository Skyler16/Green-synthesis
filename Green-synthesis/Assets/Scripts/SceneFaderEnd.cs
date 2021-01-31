using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFaderEnd : MonoBehaviour
{
    public Image endFader; 
    public Text con;
    public float speed = 0.3f;

    private float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        endFader.color = new Color(173f / 255f, 173f / 255f, 173f / 255f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha <= 1)
        {
            alpha += Time.deltaTime * speed;
            endFader.color = new Color(173f / 255f, 173f / 255f, 173f / 255f, alpha);
            con.color = new Color(204f / 255f, 0 / 255f, 17f / 255f, alpha);

        }
        //Debug.Log("true");


    }

}
