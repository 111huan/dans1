using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Transform me, zombie;
    private SpriteRenderer obj;
    public static bool pickable = false;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<SpriteRenderer>();
        gameObject.SetActive(true);
        me = GameObject.Find("me").transform;
        zombie = GameObject.Find("zombie").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth.zombieDie)
        {
            transform.position = new Vector3(transform.position.x,5.6f, 0);
            transform.localScale = new Vector3(3f, 3f, 0);
        }
        else
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
        if (Mathf.Abs(me.position.x - transform.position.x) <= 0.3 && Mathf.Abs(me.position.y - transform.position.y) <= 0.5 && Me.equiped)
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
            gameObject.SetActive(false);
            Me.haveKey = true;
        }
    }
}