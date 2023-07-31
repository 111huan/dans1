using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Transform me, zombie;
    private SpriteRenderer obj;
    public static bool pickable = false;
    void Start()
    {
        pickable = false;
        obj = GetComponent<SpriteRenderer>();
        gameObject.SetActive(true);
        me = GameObject.Find("me").transform;
        zombie = GameObject.Find("zombie").transform;
    }

    void Update()
    {
       
        if(Me.haveKey)
        {
            if (me.localScale.x > 0)
            {
                transform.position = new Vector3(me.position.x + 0.1f, me.position.y - 0.4f, 0);
            }
            else
            {
                transform.position = new Vector3(me.position.x, me.position.y - 0.4f, 0);
            }
        }
        else if (zombieHealth.zombieDie)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            transform.localScale = new Vector3(3f, 3f, 0);
        }
        else if (!zombieHealth.zombieDie)
        {
            if (zombie.localScale.x > 0)
            {
                transform.position = new Vector3(zombie.position.x + 0.27f, zombie.position.y - 0.3f, 0);
            }
            else
            {
                transform.position = new Vector3(zombie.position.x - 0.27f, zombie.position.y - 0.3f, 0);
            }
        }
        picked();
    }

    void picked()
    {
        if (Mathf.Abs(me.position.x - transform.position.x) <= 0.3 && Mathf.Abs(me.position.y - transform.position.y) <= 0.5 && Me.equiped &&!Me.haveKey)
        {
            obj.material.color = Color.green;
            pickable = true;
        }
        else
        {
            obj.material.color = Color.white;
            pickable = false;
        }
        if (pickable && Input.GetKey(KeyCode.F))
        {
            pickable = false;
            obj.material.color = Color.white;
            transform.localScale = new Vector3(2f, 2f, 0);
            Me.haveKey = true;
        }
    }
}