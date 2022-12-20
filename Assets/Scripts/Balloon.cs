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
       /* left = GameObject.Find("balloonL").transform;
        right = GameObject.Find("balloonR").transform;
        leftX = left.localPosition.x;
        rightX = right.localPosition.x;*/
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(Me.attacking && Mathf.Abs(transform.position.x-me.position.x)<= 3 && Mathf.Abs(transform.position.y - me.position.y) <= 3)
        {
            gameObject.SetActive(false);
        }
    }

    void move()
    {
        pos = transform.position;
        if (faceLeft)
        {
            pos.x -= speed * Time.deltaTime;
            this.transform.position = pos;
            if (transform.position.x <= 2)
            {
                faceLeft = false;
            }
        }
        else
        { 
            pos.x += speed * Time.deltaTime;
            this.transform.position = pos;
            if (transform.position.x > 11)
            {
                faceLeft = true;
            }
        }
    }
}
