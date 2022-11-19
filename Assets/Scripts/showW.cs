using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showW : MonoBehaviour
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
        transform.position = new Vector3(me.position.x, me.position.y + 1f, 1);
        if (me.transform.position.x >= -9)
        {
            transform.localScale = new Vector3(2.327969f, 2.327969f, 0);
            if (Input.GetKeyDown(KeyCode.W))
            {
                gameObject.SetActive(false);
            }
        }    
    }
}