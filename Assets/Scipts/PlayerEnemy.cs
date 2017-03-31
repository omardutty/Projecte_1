using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour {


    private Rigidbody2D myRigidbody;

    private Animator myAnimator;
    
    [SerializeField]
    private float movSpeed;
    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float growndRadius;

    [SerializeField]
    private LayerMask WhatIsGrownd;
    private bool isGrownded;
    private bool jump;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    // Use this for initialization
    void Start () {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();


    }

    void Update()
    {
        HandleInput();
        
    }

    // Update is called once per frame
    void FixedUpdate() { 

        float horizontal = Input.GetAxis("Horizontal");

        isGrownded = IsGrownded();

        

        Moviments(horizontal);
       Flip(horizontal);
        

    }

    private void Moviments(float horizontal) {


        myRigidbody.velocity = new Vector2(horizontal*movSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (isGrownded && jump)
        {
            isGrownded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
          
            jump = false;
        }
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            jump = true; 
        }


    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
         {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


    private bool IsGrownded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, growndRadius, WhatIsGrownd);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }

        }
        return false;
    }
}
