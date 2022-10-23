using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    public Slider slider;
    public Toggle toggle;
    public AudioSource bgm;

    // Start is called before the first frame update
    public void audioControl()
    {
        if (toggle.isOn)
        {
            bgm.gameObject.SetActive(true);
            volume();
        }
        else
        {
            bgm.gameObject.SetActive(false);
        }
    }

    public void volume()
    {
        bgm.volume = slider.value;
    }

}
