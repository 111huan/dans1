using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Me.isAttacked && !Me.attacking)
        {
            slider.value -=  5f* Time.deltaTime;
        }
        if(slider.value == 0)
        {
            SceneManager.LoadScene("demo1");
        }
    }
}
