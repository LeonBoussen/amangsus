using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Animator ani;
    public bool flipX;
    private SpriteRenderer mySpriteRenderer;
    AudioSource Walk;
    public GameObject WalkSound;

    private Vector2 moveDirection;

    public float walkDelay;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Walk = WalkSound.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        processInputs();
        //if(myAnimation)
        //{
        //myAnimation.gameObject.GetComponent<Animator>().enabled = true;
        //}
        //else
        //{
        //myAnimation.gameObject.GetComponent<Animator>().enabled = false;
        //}

        //rechts
        if (Input.GetKey("a"))
        {
            ani.enabled = true;
            Playsound();
            if (mySpriteRenderer != null)
            {
                // flip the sprite

                mySpriteRenderer.flipX = true;
            }
        }
        else
        {
            ani.enabled = false;
        }
        //achter en voor
        if (Input.GetKey("s") | Input.GetKey("w"))
        {
            Playsound();
            ani.enabled = true;
        }

        //links
        if (Input.GetKey("d"))
        {
            Playsound();
            ani.enabled = true;
            mySpriteRenderer.flipX = false;
        }        
    }

    void FixedUpdate()
    {
        Move();
    }


    void processInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Playsound()
    {
        timer += Time.deltaTime;
        if (timer > walkDelay)
        {
            Walk.Play();
            timer = 0.0f;
        }
    }
}
