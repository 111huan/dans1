using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody;
    public Animator anim;
    public SpriteRenderer obj;
    public Transform zombie;
    bool isJumpable = true;
    public static bool isClimbing = false;
    public static bool isAttacked = false;
    public static bool attacking = false;
    float force = 300.0f;
    public float speed_x = 2f;
    public float speedY = 2f;
    public static bool isOnFixedLadder = false;
    public bool isDrifting = false;
    public static bool equiped = false;
    public static bool haveKey = false;
    private float attackTime = 0f;
    private float walkInSpeed = 0.05f;
    public static Vector3 startClimbPosition;
    void Start()
    {
        isAttacked = false;
        attacking = false;
        equiped = false;
        obj = GetComponent<SpriteRenderer>();
        zombie = GameObject.Find("zombie").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Door.opened)
        {
            StartCoroutine("WalkIn");
        }
        if (equiped)
        {
            attack();
        }
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
        if (isClimbing)
        {
            climb();
            if (Input.GetKeyDown(KeyCode.F) && Mathf.Abs(transform.position.y-ladder.bottom.position.y)<=1.5)//if me wanna back to ground
            {
                isClimbing = false;
                transform.position = startClimbPosition;
                this.rigidbody.gravityScale = 3;
            }
            else if(Input.GetKeyDown(KeyCode.F) && Mathf.Abs(transform.position.y - ladder.top.position.y) <= 1)
            {
                isClimbing = false;
                transform.position = ladder.arrivePos;
                this.rigidbody.gravityScale = 3;
            }
        }
        else if (ladder.climbable && Input.GetKeyDown(KeyCode.F))// if me is  ready to climb
        {
            isClimbing = true;
            ladder.climbable = false;
            transform.position = ladder.bottom.position;
            rigidbody.gravityScale = 0;
            startClimbPosition = transform.position;
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

    IEnumerator WalkIn()
    {
        Door.opened = false;
        this.rigidbody.gravityScale = 0;
        for (int i = 0; i < 5; i++)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y + 0.01f, 0);
            yield return new WaitForSeconds(walkInSpeed);
        }
        this.rigidbody.gravityScale = 3;
    }
    void attack()
    {
         if (!attacking)
         {
             if (Input.GetKeyDown(KeyCode.F))
             {
                 attacking = true;
                 anim.SetFloat("attacking", 1);
                 attackTime = Time.time + 0.2f;
             }
         }
         if (Time.time >= attackTime && attacking)
         {
             attacking = false;
             anim.SetFloat("attacking", 0);
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
       /* if (isOnFixedLadder)
        {
            limitY = 5.5f;
        }
        else
        {
            limitY = ladder.top.localPosition.y;
        }*/
        if (Input.GetKey(KeyCode.W) && pos.y < ladder.top.position.y)
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
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, 0);
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
            if (!attacking)
            {
                float faceleft = -1f;
                obj.material.color = Color.red;
                if (zombie.localScale.x > 0)
                {
                    faceleft = -1f;
                }
                else
                {
                    faceleft = 1f;
                }
                Debug.Log(faceleft);
                rigidbody.AddForce(Vector2.right * faceleft * 80f);
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
            obj.material.color = Color.white;
        }
    }
}
