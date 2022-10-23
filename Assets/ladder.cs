using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private Transform me;
    public static Transform bottom, top;
    private Renderer obj;
    public static bool climbable = false;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
        obj = GetComponent<Renderer>();
        bottom = GameObject.Find("down").transform;
        top = GameObject.Find("up").transform;
    }

    // Update is called once per frame
    void Update()
    {
        monitor();
    }

    private void monitor()
    {
        if(Mathf.Abs(me.position.x-transform.position.x)<=2 && Mathf.Abs(me.position.y - transform.position.y) <= 3)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
            climbable = true;
        }
        else
        {
            obj.GetComponent<Renderer>().material.color = Color.white;
            climbable = false;
        }
    }
}
