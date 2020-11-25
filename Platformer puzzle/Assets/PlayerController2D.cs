using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public Vector2 pos_init;
    public GameObject playerClone;
    Vector2 PressPos;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;

    bool isGrounded, flag=true;
    public int currentStage = 1, buttonCount = 0;

    [SerializeField]
    Transform groundCheck, groundCheck2;
   


    // Start is called before the first frame update
    void Start()
    {
        // Assign variables and initialize
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d.centerOfMass = new Vector2(rb2d.centerOfMass.x, 0);
        UIButtonManager ui = GameObject.FindGameObjectWithTag("Managers").GetComponent<UIButtonManager>();
        ui.Init();

        // Set current position according to PlayerPrefs
        if (PlayerPrefs.HasKey("currentStage"))
        {
            currentStage = PlayerPrefs.GetInt("currentStage");
            pos_init = new Vector2(transform.position.x + 19 * (currentStage - 1), transform.position.y);
        }
        else if(PlayerPrefs.HasKey("highestStage"))
        {
            currentStage = PlayerPrefs.GetInt("highestStage");
            pos_init = new Vector2(transform.position.x + 19 * (currentStage - 1), transform.position.y);
        }
        else
        {
            pos_init = transform.position;
        }
        initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentStage != 9 || buttonCount != 3)
        {
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            
            if ((Input.GetKeyDown("space") || inputJump) && isGrounded)
            {

                rb2d.AddForce(new Vector2(0, 120), ForceMode2D.Impulse);
                AudioManager.instance.PlaySE("jump");
                inputJump = false;
            }

            if (!isGrounded)
            {
                if (rb2d.velocity.y > 0)
                {
                    animator.Play("jump_up");
                }
                else
                {
                    animator.Play("jump_down");
                }

                if (Input.GetKey("right") || inputRight)
                {
                    rb2d.velocity = new Vector2((float)3.5, rb2d.velocity.y);
                    spriteRenderer.flipX = false;
                }
                else if (Input.GetKey("left") || inputLeft)
                {
                    rb2d.velocity = new Vector2((float)-3.5, rb2d.velocity.y);
                    spriteRenderer.flipX = true;
                }
                else
                {
                    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                }
            }
            else
            {
                if (Input.GetKey("right") || inputRight)
                {
                    rb2d.velocity = new Vector2((float)3.5, rb2d.velocity.y);
                    animator.Play("run");
                    spriteRenderer.flipX = false;
                }
                else if (Input.GetKey("left") || inputLeft)
                {
                    rb2d.velocity = new Vector2((float)-3.5, rb2d.velocity.y);
                    animator.Play("run");
                    spriteRenderer.flipX = true;
                }
                else
                {
                    animator.Play("idle");
                    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                }
            }
        }
        else
        {
            float gx = Input.acceleration.x * 9.81f;
            float gy = Input.acceleration.y * 9.81f;
            if (rb2d.velocity.y > 0)
            {
                animator.Play("jump_up");
            }
            else
            {
                animator.Play("jump_down");
            }
            Physics2D.gravity = new Vector2(gx, gy);
        }

        if(currentStage == 12)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                PressPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                print(PressPos);

                if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(PressPos))
                {
                    createCopy();
                }


            }

            if (Input.touchCount > 0)
            {   
                
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        if (flag)
                        {
                            createCopy();
                            flag = false;
                        }
                    }
                }else if(touch.phase == TouchPhase.Ended)
                {
                    flag = true;
                }

            }


        }



        
    }
    
    public void initialize()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = pos_init;
    }


    public void createCopy()
    {
        Instantiate(playerClone, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
    }
}
