using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Transform left, right,me;
    Vector3 pos;
    float speed = 1,leftX,rightX;
    bool faceLeft = true;
    bool beingAttacked = false;
    void Start()
    {
        gameObject.SetActive(true);
        me = GameObject.Find("me").transform;
        left = GameObject.Find("balloonL").transform;
        right = GameObject.Find("balloonR").transform;
        leftX = left.position.x;
        rightX = right.position.x;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(Me.attacking && Mathf.Abs(transform.position.x-me.position.x)<= 3 && Mathf.Abs(transform.position.y - me.position.y) <= 3)
        {
            Debug.Log("111");
            gameObject.SetActive(false);
        }
    }

    void move()
    {
        if (faceLeft)
        {
            pos.x -= speed * Time.deltaTime;
            this.transform.localPosition = pos;
            if (transform.position.x <= leftX)
            {
                faceLeft = false;
            }
        }
        else
        { 
            pos.x += speed * Time.deltaTime;
            this.transform.localPosition = pos;
            if (transform.position.x > rightX)
            {
                faceLeft = true;
            }
        }
    }
}
