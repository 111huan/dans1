using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody;
    public Animator anim;
    public Renderer obj;
    bool isJumpable = true;
    bool isClimbing = false;
    public static bool isAttacked = false;
    float force = 300.0f;
    public float speed_x = 2f;
    public float speedY = 2f;
    private bool isOnFixedLadder = false;
    public bool isDrifting = false;
    public static bool equiped = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        obj = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrifting)
        {
            anim.SetFloat("swimming", 1);
            drift();
        }
        else
        {
            anim.SetFloat("swimming", 0);
        }
        if (transform.position.x < 9.4 && transform.position.x > 7.5 && transform.position.y > -0.7)
        {
            isOnFixedLadder = true;
        }
        else
        {
            isOnFixedLadder = false;
        }
        if (isOnFixedLadder)
        {
            isClimbing = false;
            climb();
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOnFixedLadder = false;
                transform.position = new Vector3(7f, 3.3f, 0);
                this.rigidbody.gravityScale = 3;
                Debug.Log(isClimbing);
                Debug.Log(rigidbody.gravityScale);
            }
        }
        else if (isClimbing)
        {
            climb();
            if (Input.GetKeyDown(KeyCode.F))
            {
                isClimbing = false;
                transform.position = new Vector3(ladder.bottom.position.x - 1.3f, ladder.bottom.position.y, 0);
                this.rigidbody.gravityScale = 3;
                Debug.Log(isClimbing);
                Debug.Log(rigidbody.gravityScale);
            }
        }
        else if (ladder.climbable && Input.GetKeyDown(KeyCode.F))
        {
            isClimbing = true;
            ladder.climbable = false;
            transform.position = ladder.bottom.position;
            rigidbody.gravityScale = 0;
            Debug.Log(isClimbing);
            Debug.Log(rigidbody.gravityScale);
        }
        else
        {
            move();
        }
        if (!equiped)
        {
            pickSword();
        }
    }

    void pickSword()
    {
        if (sword.pickable&& Input.GetKeyDown(KeyCode.F))
        {
            equiped = true;
            anim.SetFloat("holding", 1);
        }
    }
    void drift()
    {
        rigidbody.gravityScale = 0;
        float dst_x = speed_x * Time.deltaTime;
        /*transform.position = new Vector3(transform.position.x, Pool.surface, 0);*/
        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += dst_x;
            this.transform.localPosition = pos;
            transform.localScale = new Vector3(-2.3f, 2.3f, 1);

        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= dst_x;
            this.transform.localPosition = pos;
            transform.localScale = new Vector3(2.3f, 2.3f, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody.AddForce(Vector2.down * force);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector2.up * force);
        }
    }

    void move()
    {
        float facedirection = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
        {
            anim.SetFloat("running", 1);
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("running", 0);
        }

        float dst_x = speed_x * Time.deltaTime;
        Vector2 pos = this.transform.localPosition;

        //walk to right
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += dst_x;
            this.transform.localPosition = pos;
            transform.localScale = new Vector3(-2.3f, 2.3f, 1);
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= dst_x;
            this.transform.localPosition = pos;
            transform.localScale = new Vector3(2.3f, 2.3f, 1);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.W) && isJumpable == true)
        {
            rigidbody.AddForce(Vector2.up * force);
        }
    }


    void climb()
    {
        Vector2 pos = this.transform.localPosition;
        float limitY = 0;
        if (isOnFixedLadder)
        {
            limitY = 3.3f;
        }
        else
        {
            limitY = ladder.top.localPosition.y;
        }
        if (Input.GetKey(KeyCode.W)&&pos.y < limitY)
         {
                pos.y += speedY * Time.deltaTime;
                this.transform.localPosition = pos;

         }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speedY * Time.deltaTime;
            this.transform.localPosition = pos;

        }
        this.transform.localPosition = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumpable = true;
        }
        if (collision.gameObject.tag == "water")
        {
            isDrifting = true;
            rigidbody.velocity = new Vector2(0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        }
        if (collision.gameObject.tag == "edge")
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 1f, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            isDrifting = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.gravityScale = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && !isDrifting)
        {
            isJumpable = true;
        }
        if (collision.gameObject.tag == "zombieHand")
        {
            isAttacked = true;
            if (!equiped)
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumpable = false;
        }
        if (collision.gameObject.tag == "zombieHand")
        {
            isAttacked = false;
            obj.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
