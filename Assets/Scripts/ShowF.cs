using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowF : MonoBehaviour
{
    Transform me;
    Transform zombie;
    bool nearZombie;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
        zombie = GameObject.Find("zombie").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(me.position.x - zombie.position.x) <= 3 && Mathf.Abs(me.position.y - zombie.position.y) <= 1 && !zombieHealth.zombieDie) 
        {
            nearZombie = true;
        }
        else
        {
            nearZombie = false;
        }

        if (sword.pickable || ladder.climbable ||(Me.equiped && nearZombie) || Key.pickable || Door.openable || (me.transform.position.y>5.4 && Me.isOnFixedLadder))
        {
            transform.position = new Vector3(me.position.x, me.position.y + 1f, 1);
            transform.localScale = new Vector3(2f, 2f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0f, 2f, 1);
        }
    }
}
