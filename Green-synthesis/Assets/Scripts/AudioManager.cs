using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private Slider volume;

    public AudioSource bgm;
    

    // Start is called before the first frame update
    void Start()
    {
        bgm = bgm.GetComponent<AudioSource>();
        volume = GetComponent<Slider>();
        volume.value = bgm.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeController()
    {
        bgm.volume = volume.value;
    }
}
