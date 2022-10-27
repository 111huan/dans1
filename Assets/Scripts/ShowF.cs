using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowF : MonoBehaviour
{
    Transform me;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("me").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (sword.pickable || ladder.climbable ||(Me.equiped && Me.isAttacked) || Key.pickable || Door.openable)
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
