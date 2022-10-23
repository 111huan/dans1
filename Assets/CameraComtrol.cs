using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComtrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform me;
    void Update()
    {
        transform.position = new Vector3(me.position.x, me.position.y, -10f);
    }
}
