using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Transform me;
    public static bool openable = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        me = GameObject.Find("me").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Me.haveKey && me.position.x<=-12f && me.position.x >= -14f)
        {
            openable = true;
        }
        else
        {
            openable = false;
        }
        if (openable && Input.GetKey(KeyCode.F))
        {
            openable = false;
            gameObject.SetActive(false);
        }
    }
}
