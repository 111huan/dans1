using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target,me;
    public SpriteRenderer obj;
    public Transform leftpoint, rightpoint;
    public Animator anim;
    private bool faceLeft = false,stop = false;
    public float speed = 5;
    private float leftx, rightx;
    private float vision = 3;
    private float attackRange = 0.4f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        me = GameObject.Find("me").transform;
        obj = GetComponent<SpriteRenderer>();
        gameObject.SetActive(true);
        target = GameObject.Find("me").transform;
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
       // transform.DetachChildren();
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        transform.localPosition = transform.localPosition;
        transform.localScale = new Vector3(-2.7f, 2.7f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        attacked();
        if (zombieHealth.zombieDie)
        {
            print("zombieHealth.zombieDie");
            transform.localPosition = new Vector3(-1000, -1000, 0);
            //transform.localScale = new Vector3(0, 0, 0);
        }
        if (Mathf.Abs(target.position.x - transform.position.x) > vision && !stop)
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

    void attacked()
    {
        if (Mathf.Abs(me.transform.position.x-transform.position.x)<=1 && Me.attacking)
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
            rb.AddForce(Vector2.right * faceleft * 120f);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float faceleft = -1f;
        if (collision.gameObject.tag == "me")
        {
            obj.material.color = Color.red;
            if (transform.localScale.x > 0)
            {
                faceleft = 1f;
            }
            else
            {
                faceleft = -1f;
            }
            Debug.Log(faceleft);
            rb.AddForce(Vector2.right * faceleft * 120f);
        }
        if(collision.gameObject.tag == "balloon")
        {
            stop = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "me")
        {
            obj.material.color = Color.white;
        }
        if (collision.gameObject.tag == "balloon")
        {
            stop = false;
        }
    }
}
