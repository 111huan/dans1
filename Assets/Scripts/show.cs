using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{
    Transform me;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (me.position.y >= -4 && me.position.y <= -3.2)
        {
            transform.position = new Vector3(me.position.x, me.position.y + 1f, 1);
            transform.localScale = new Vector3(2f, 2f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0f, 2f, 1);
        }
    }
}
