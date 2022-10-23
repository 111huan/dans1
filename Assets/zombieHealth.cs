using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class zombieHealth : MonoBehaviour
{
    private Transform zombie;
    public Slider slider;
    public static bool zombieDie = false;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        zombie = GameObject.Find("zombie").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test");
        Debug.Log("equpiped:" + Me.equiped + "isAttackeda;" + Me.isAttacked);
        transform.position = new Vector3(zombie.position.x, zombie.position.y + 1f, 0);
        if (Me.equiped && Me.isAttacked)
        {
            slider.value -= 5f* Time.deltaTime;
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
