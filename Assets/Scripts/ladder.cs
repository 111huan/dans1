using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private Transform me;
    public static Transform bottom, top, work,arrive;
    private Renderer obj;
    public static bool climbable = false;
    public static Vector3 arrivePos,workPos;// position of th center of where the ladder works
    void Start()
    {
        me = GameObject.Find("me").transform;
        obj = GetComponent<Renderer>();
       bottom = GameObject.Find("down").transform;
        top = GameObject.Find("up").transform;
        work = GameObject.Find("work").transform;
        arrive = GameObject.Find("arrive").transform;
        workPos = work.position;
        arrivePos = arrive.position;
    }

    // Update is called once per frame
    void Update()
    {
        monitor();
    }
    
    private void monitor()
    {
        if(Mathf.Abs(me.position.x-transform.position.x)<=1.3 && Mathf.Abs(me.position.y - transform.position.y) <= 3 &&
            !Me.isClimbing  && Mathf.Abs(workPos.x - transform.position.x) <= 1)
            //make sure: 1.me is besides the ladder 2.the ladder is in a range where it should work 
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
