using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class PlayerEnemy : MonoBehaviour {
    public HUD hud;

    public Scene Already;

    private Rigidbody2D myRigidbody;
    private bool aspitjat = false;
    private bool agachado = false;
    public bool canpass = false;
    private Animator myAnimator;

    [SerializeField]
    public int numero;
    

    [SerializeField]
    private float movSpeed;
    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float growndRadius;

    [SerializeField]
    private LayerMask WhatIsGrownd;
    [SerializeField]
    private bool isGrownded;
    private bool jump;

    // Escales
    [SerializeField]
    public bool onLadder;
    public float ClimbSpeed;
    private float ClimbVelocity;
    private float gravityStore;

    //Puerta
    [SerializeField]
    public bool nearDoor;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private GameObject bala;

    //Puzzle
    public int obj;
    //Balas Del player
    public int currentBalas;
    public int maxBalas = 3;

    public Transform spawnBala;
    public GameObject balaPrefab;

    public bool pinchando;

    void Start () {

        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        gravityStore = GetComponent<Rigidbody2D>().gravityScale;
        currentBalas = maxBalas;
    }

    void Update()
    {
        HandleInput();

        if (onLadder)
        {
            myRigidbody.gravityScale = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                //ClimbVelocity = ClimbSpeed;
                //myRigidbody.velocity = new Vector2(0, ClimbVelocity);
                myRigidbody.transform.Translate(new Vector2(0.0f, 0.06f));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //myRigidbody.gravityScale = gravityStore;
                myRigidbody.transform.Translate(new Vector2(0.0f, -0.06f));
            }
        }
        if (!onLadder) {
            myRigidbody.gravityScale = gravityStore;
        }

    }
    
    void FixedUpdate() { 

        float horizontal = Input.GetAxis("Horizontal");

        isGrownded = IsGrownded();

       

        Moviments(horizontal);
        Flip(horizontal);

    }

    private void Moviments(float horizontal) {
        if (agachado == false)
        {
            myRigidbody.velocity = new Vector2(horizontal * movSpeed, myRigidbody.velocity.y);
            myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        }
        else
        {
            myRigidbody.velocity = new Vector2(0, 0);
            myAnimator.SetFloat("Speed", 0);
        }        
    }


    private void HandleInput()
    {
       if (Input.GetKeyDown(KeyCode.W) && isGrownded && !onLadder)
        {
            isGrownded = true;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            jump = false;

        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            myAnimator.SetBool("Agachado", true);
            agachado = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            myAnimator.SetBool("Agachado", false);
            agachado = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("Shot", true);

            if (maxBalas >= 4)
            {
                shotbala();
                maxBalas = maxBalas - 1;
                // hud.GetComponent<SpriteRenderer>();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myAnimator.SetBool("Shot", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            pinchando = true;
            myAnimator.SetBool("cuchillando", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            pinchando = false;
            myAnimator.SetBool("cuchillando", false);
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

    public void shotbala() {
        Instantiate(bala, spawnBala.position, spawnBala.rotation);
    }

}
