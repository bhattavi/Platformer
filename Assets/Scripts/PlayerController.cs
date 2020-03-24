using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public LayerMask ground;
    Rigidbody2D rb;
    Vector2 force;
    Animator anim;
    bool facingRight = true;
    bool jumpPending = false;
    AudioSource audioSource;
    public AudioClip clipJump;
    public AudioClip clipDanger;
    //public static int numLives;
    public static int numLives=3;
    public string currentScene;
    public Text lives;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
      
        lives.text = numLives.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
      
       
        force = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
          
            force.x = -10;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x, transform.position.y - 0.75f);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);

            if (grounded)
            {
                //force.y = 300;
                audioSource.clip = clipJump;
                audioSource.Play();
                jumpPending = true;
              
                //Debug.Log("spacebar pressed");
            }
        }
        if (force.x < 0)
        {
            anim.SetBool("isWalking", true);
            if (facingRight) Flip();

        }else if (force.x > 0)
        {
            anim.SetBool("isWalking", true);
            if (!facingRight) Flip();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")

        {
            audioSource.clip = clipDanger;
            audioSource.Play();
            numLives--;
            lives.text = numLives.ToString();
            if (numLives >= 1)
            {
                SceneManager.LoadScene(currentScene);
            }
            if (numLives < 1)
            {
                numLives = 3;
                SceneManager.LoadScene("FailedScene");
            }
        }

    }
   
    
    private void FixedUpdate()
    {
        if (jumpPending)
        {
            
            force.y = 300;
           
            jumpPending = false;
        }
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), rb.velocity.y);
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }




}

