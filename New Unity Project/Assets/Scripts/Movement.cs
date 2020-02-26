using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    public Animator animator;
    public Rigidbody2D m_Rigidbody2D;
    private float m_JumpForce = 150f;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jumping = false;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;
    private SpriteRenderer spriteRenderer;
    public Sprite slime, full, twohp, onehp, dead, fireicon, watericon, airicon, earthicon, emptyicon;
    public Sprite morph;
    [SerializeField] public GameObject ball;
    public Transform ballZone;
    public Rigidbody2D rbb;
    public Image healthimage, formicon;
    public AudioSource music1;
    Vector3 shootDirection;
    public AudioSource coin;
    public GameObject coinsound;

    public int jumps = 2;
    public int score = 0;
    public bool underwater = false;
    public bool fireproof = false;
    public int breath;

    public int form;
    public int health;


    // Use this for initialization----------------------------------------------------------
    void Start () {
        
        health = 3;
        form = 0;
        score = 0;
        PlayerPrefs.SetInt("Bullet", 0);
        formicon.sprite = emptyicon;

	}
    //Collisions --------------------------------------------------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Earth Form----------------------------------------------------------
        if(coll.gameObject.tag == "SlimedEarth")
        {
            underwater = false;
            fireproof = false;
            formicon.sprite = earthicon;
                this.GetComponent<SpriteRenderer>().sprite = morph;
                animator.SetInteger("currentForm", 1);
                form = 1;
                Debug.Log("transformed");
                if (health < 3)
                {
                    health++;
                }
            
        }
        //Fire Form----------------------------------------------------------
        if (coll.gameObject.tag == "SlimedFire")
        {
            fireproof = true;
            underwater = false;
            formicon.sprite = fireicon;
                form = 2;
                Debug.Log("transformed");
                if (health < 3)
                {
                    health++;
                }
            
        }

        //Water Form----------------------------------------------------------
        if (coll.gameObject.tag == "SlimedWater")
        {
            fireproof = false;
            underwater = true;
            formicon.sprite = watericon;
                form = 3;
                Debug.Log("transformed");
                if (health < 3)
                {
                    health++;
                }
            
        }
        //Air Form----------------------------------------------------------
        if (coll.gameObject.tag == "SlimedAir")
        {
            fireproof = false;
            underwater = false;
            formicon.sprite = airicon;
                form = 4;
                Debug.Log("transformed");
                if (health < 3)
                {
                    health++;
                    jumps = 2;
                }
            
        }
        //---------------------------------------------------------------------
        if(coll.gameObject.tag == "LifeGate")
        {
            health--;
        }
        //Ground
        if (coll.gameObject.tag == "Ground")
        {
            jumping = false;
            animator.SetBool("isJumping", false);
            if(form == 4)
            {
                jumps = 2;
            }
            else
            {
                jumps = 0;
            }
        }
        //Wall
        if(coll.gameObject.tag == "Wall")
        {
            
        }
        //Enemy Collisions
        if(coll.gameObject.tag == "Earth")
        {
            health--;
        }
        if (coll.gameObject.tag == "Fire")
        {
            health--;
        }
        if (coll.gameObject.tag == "Air")
        {
            health--;
        }
        if (coll.gameObject.tag == "Water")
        {
            health--;
        }
        //Projectiles
        if (coll.gameObject.tag == "EnemyBullet")
        {
            health--;
        }
        //Score
        if(coll.gameObject.tag == "Coin")
        {
            score++;
            Instantiate(coinsound, transform.position, transform.rotation);
            coin.Play();
            
        }
        //Health Recovery
        if(coll.gameObject.tag == "Health" && health < 3)
        {
            health++;
        }
        if (coll.gameObject.tag == "Sea" && underwater == false)
        {
            Die();
        }
        if (coll.gameObject.tag == "Wildfire" && fireproof == false)
        {
            health--;
        }
        if (coll.gameObject.tag == "Spike")
        {
            Die();
        }

        if (coll.gameObject.tag == "Boss")
        {
            health--;
        }
        
    }
    //Trigger Handler---------------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
        }

        if (collision.gameObject.tag == "Wildfire" && fireproof == false)
        {
            health--;
        }

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag == "Health" && health < 3)
        {
            health++;
        }

        if(collision.gameObject.tag == "Sea")
        {
            Die();
        }

        if (collision.gameObject.tag == "Sea" && underwater == true)
        {
            
        }
    }
    //-------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update () {
        //Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));

        if (jumping == false && Input.GetKeyDown(KeyCode.Space))
        {
            if(form == 4 && jumps > 0)
            {
                
                jumps--;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce ));
                animator.SetBool("isJumping", true);
                
            }
            
            if (form != 4)
            {
                jumping = true;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                animator.SetBool("isJumping", true);
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        //Form handler --------------------------------------------------------------------------
        if (form == 1)
        {
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if(transform.localScale.x > 0)
                {
                    m_Rigidbody2D.AddForce(new Vector2(40f, 0f));
                }

                if (transform.localScale.x < 0)
                {
                    m_Rigidbody2D.AddForce(new Vector2(-40f, 0f));
                }
            }
        }

        if (form == 2)
        {
            //FireImmunity
            
        }

        if (form == 3)
        {
            //WaterBreathing
            
        }
        //Shooting------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.F) && PlayerPrefs.GetInt("Bullet") == 0 && health > 1)
        {
            
                shootDirection = Input.mousePosition;
                shootDirection.z = 0.0f;
                shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
                shootDirection = shootDirection - transform.position;
                //Instantiate(ball, ballZone.position, ballZone.rotation);
                Rigidbody2D bulletInstance = Instantiate(rbb, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(shootDirection.x * 1, shootDirection.y * 1);
                health--;
                PlayerPrefs.SetInt("Bullet", 1);
            



        }
        //Health--------------------------------------------------------------------------------
        if (health == 3)
        {
            
            healthimage.sprite = full;
        }
        if (health == 2)
        {
            
            healthimage.sprite = twohp;
        }
        if (health == 1)
        {
            
            healthimage.sprite = onehp;
        }
        if (health == 0)
        {
            healthimage.sprite = dead;
            Die();
        }

    }
    //--------------------------------------------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime, false, jumping);

        
    }
    //--------------------------------------------------------------------------------------------------------------------
    public void Move(float move, bool crouch, bool jump)
    {


        //only control the player if grounded or airControl is turned on





        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip1();
            
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
            
        }


    }

    //--------------------------------------------------------------------------------------------------------------------
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        if(health == 1)
        {
            transform.localScale = new Vector2(-2, 2);
        }
        if(health == 2)
        {
            transform.localScale = new Vector2(-3, 3);
        }
        if (health == 3)
        {
            transform.localScale = new Vector2(-4, 4);
        }
        
    }

    private void Flip1()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        if (health == 1)
        {
            transform.localScale = new Vector2(2, 2);
        }
        if (health == 2)
        {
            transform.localScale = new Vector2(3, 3);
        }
        if (health == 3)
        {
            transform.localScale = new Vector2(4, 4);
        }

    }

    //Old Code breaks if removed unsure why--------------------------------------------------------------------------------------------------------------------
    public void CollisionDetected (BiteHit bitehit)
    {
        Debug.Log("Collision");
    }
    //--------------------------------------------------------------------------------------------------------------------
    public void Die()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    //--------------------------------------------------------------------------------------------------------------------
    private void Swing()
    {

    }


}
