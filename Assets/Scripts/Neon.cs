using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neon : MonoBehaviour
{
    public SpriteRenderer obj;
    float alpha = 1f;
    bool isTrans = true;
    float transSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha >= 1)
        {
            isTrans = true;
            alpha = 1;
        }
        if (isTrans)
        {
            alpha -= transSpeed * Time.deltaTime * 60;
        }
        if(alpha <= 0)
        {
            isTrans = false;
            alpha = 0;
        }
        if (!isTrans)
        {
            alpha += transSpeed * Time.deltaTime * 30;
        }
        obj.material.color = new Color(obj.color.r, obj.color.g, obj.color.b, alpha);
    }
}
