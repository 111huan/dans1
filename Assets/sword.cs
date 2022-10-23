using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private Transform me;
    private Renderer obj;
    public static bool pickable = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        me = GameObject.Find("me").transform;
        obj = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        monitor();
        if (Me.equiped)
        {
            gameObject.SetActive(false);
        }
    }

    private void monitor()
    {
        if (Mathf.Abs(me.position.x - transform.position.x) <= 2 && Mathf.Abs(me.position.y - transform.position.y) <= 3)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
            pickable = true;
        }
        else
        {
            obj.GetComponent<Renderer>().material.color = Color.white;
            pickable = false;
        }
    }
}
