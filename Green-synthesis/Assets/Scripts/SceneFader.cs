using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    
    public float speed = 0.3f;

    private float alpha = 1;
    private Image fader;
    // Start is called before the first frame update
    void Start()
    {
        fader = GetComponent<Image>();
        fader.color = new Color(173f / 255f, 173f / 255f, 173f / 255f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha >= 0)
        {
            alpha -= Time.deltaTime * speed;
            fader.color = new Color(173f / 255f, 173f / 255f, 173f / 255f, alpha);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }

}
