using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingEnemy : MonoBehaviour {

   
    public GameObject player;
    private Transform playerTrans;

    private Rigidbody2D bulletRB;

    public float bulletSpeed;


    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    void Start()
    {
        if (playerTrans.localScale.x > 0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(0.82f, 0.39f, 1);
        }
        else{
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(-0.82f, 0.39f, 1);
        }
   }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "escenari" || collision.tag == "Enemy1")

            Destroy(gameObject);
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }

    
}
