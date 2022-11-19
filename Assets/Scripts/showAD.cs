using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showAD : MonoBehaviour
{
    Transform me;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
        transform.localScale = new Vector3(2.327969f, 2.327969f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag=="A")
        {
            transform.position = new Vector3(me.position.x-1f, me.position.y, 1);
            transform.localScale = new Vector3(2.327969f, 2.327969f, 0);
            if (Input.GetKeyDown(KeyCode.A))
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            transform.position = new Vector3(me.position.x + 1f, me.position.y, 1);
            transform.localScale = new Vector3(2.327969f, 2.327969f, 0);
            if (Input.GetKeyDown(KeyCode.D))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
