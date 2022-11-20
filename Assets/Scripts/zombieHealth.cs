using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class zombieHealth : MonoBehaviour
{
    private Transform zombie,me;
    public static Slider slider;
    public static bool zombieDie = false;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
        slider = GetComponent<Slider>();
        zombie = GameObject.Find("zombie").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(zombie.position.x, zombie.position.y + 1f, 0);
        if (Me.attacking && Mathf.Abs(me.transform.position.x - transform.position.x) <= 1)
        {
            slider.value -=  9f * Time.deltaTime;
        }
        if (slider.value == 0)
        {
            zombieDie = true;
        }
        if (zombieDie)
        {
            gameObject.SetActive(false);
        }
    }
}
