using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private BoxCollider2D FOV;
    private GameObject enemy;
    public GameObject startPoint;
    public PlayerEnemy myPlayer;
    public GameObject endPoint;
    private GameObject area;
    public bool right = true;

    public float enemySpeed;
    public bool goRight;

    public ShootingEnemy range;


    // Use this for initialization
    void Start()
    {
        if (!goRight)
        {
            transform.position = startPoint.transform.position;
            

        }
        else
        {
            transform.position = endPoint.transform.position;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!goRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed);
            if (transform.position == endPoint.transform.position)
            {
                goRight = true;
                GetComponent<SpriteRenderer>().flipX = false;
              
            }
        }
        if(goRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed);
            if (transform.position == startPoint.transform.position)
            {
                goRight = false;
                GetComponent<SpriteRenderer>().flipX = true;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && myPlayer.pinchando && this.tag == "Enemy1")
        {
            Destroy(gameObject);
        }

    }
}

