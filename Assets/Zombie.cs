using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public Transform leftpoint, rightpoint;
    public Animator anim;
    private bool faceLeft = false;
    public float speed = 5;
    private float leftx, rightx;
    private float vision = 3;
    private float attackRange = 0.6f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        target = GameObject.Find("me").transform;
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
       // transform.DetachChildren();
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        transform.localScale = new Vector3(-2.7f, 2.7f, 0);
    }

    void attacked()
    {
        if(Me.isAttacked && Me.equiped)
        {
            float faceleft = 0f;
            if (transform.localScale.x > 0)
            {
                faceleft = 1f;
            }
            else
            {
                faceleft = -1f;
            }
            rb.AddForce(Vector2.right * faceleft * 80f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        attacked();
        if (zombieHealth.zombieDie)
        {
            gameObject.SetActive(false);
        }
        if (Mathf.Abs(target.position.x - transform.position.x) > vision)
        {
            move();
        }
        else if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            chase();
        }
        else
        {
            attack();
        }
    }
    void chase()
    {
        anim.SetFloat("attack", 0);
        if (Mathf.Abs(target.position.y - transform.position.y) < 0.5)
        {
            if (target.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector3(-2.7f, 2.7f, 1);//图像水平翻转
                faceLeft = false;
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector3(2.7f, 2.7f, 1);//图像水平翻转
                faceLeft = true;
            }
        }
    }

    void attack()
    {
        anim.SetFloat("attack", 1);
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-2.7f, 2.7f, 1);//图像水平翻转
            faceLeft = false;
        }
        else
        {
            transform.localScale = new Vector3(2.7f, 2.7f, 1);//图像水平翻转
            faceLeft = true;
        }
    }
    void move()
    {
        anim.SetFloat("attack", 0);
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-2.7f, 2.7f, 1);//图像水平翻转
                faceLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(2.7f, 2.7f, 1);//图像水平翻转
                faceLeft = true;
            }
        }
    }

   /*bool foundMe()
    {
        var colliders = Physics.OverlapSphere(transform.position, vision);
        foreach(var target in colliders)
        {
            return true;
        }
        return false;
    }*/
}
