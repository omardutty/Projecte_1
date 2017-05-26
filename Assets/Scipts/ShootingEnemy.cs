using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public GameObject player;
    public Transform enemyTrans;
    public Animator enemyAnim;
    public GameObject balaPrefab;
    public GameObject balaSpawner;
    public GameObject objection;

    public bool playerInRange;
    public float fireRate;
    private float shootingCount;
    public bool giro;

	// Use this for initialization
	void Start () {
        enemyAnim = GetComponentInParent<Animator>();
        shootingCount = 0.85f; //temps de dispar
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInRange)
        {
            objection.SetActive(true);
            IaDispara();       
        }
        else
        {
            objection.SetActive(false);
        }
    }

    void IaDispara() {

        float time = Time.deltaTime;
        shootingCount += time;
        //Debug.Log(shootingCount);

        if (shootingCount >= fireRate)
        {
            Debug.Log("disparo");
            shootingCount = 0;
            GameObject bullet = Instantiate(balaPrefab, balaSpawner.transform.position, balaSpawner.transform.rotation);
            bullet.GetComponent<BalaEnemy1>().enemy = this.gameObject.transform.parent.gameObject;
            giveSpeedToBullet(bullet.GetComponent<Rigidbody2D>());
            time = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemyAnim.SetBool("PlayerInRange", true);
            GetComponent<AudioSource>().Play();
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemyAnim.SetBool("PlayerInRange", false);
            playerInRange = false;
            shootingCount = 0;
        }
    }
    void giveSpeedToBullet(Rigidbody2D bulletRB) {

        Transform playerTrans = player.transform;
        enemyTrans = gameObject.transform;

        float bSpeed = bulletRB.GetComponent<BalaEnemy1>().bulletSpeed;

        if (playerTrans.position.x > enemyTrans.position.x)
        {
            Debug.Log("PT x: " + playerTrans.position.x + ", E x: " + enemyTrans.position.x);
            bulletRB.velocity = new Vector2(bSpeed, bulletRB.velocity.y);
            bulletRB.transform.localScale = new Vector3(-0.004707938f, 0.001673524f, 1);
            bulletRB.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (playerTrans.position.x < enemyTrans.position.x)
        {
            Debug.Log("PT x: " + playerTrans.position.x + ", E x: " + enemyTrans.position.x);
            bulletRB.velocity = new Vector2(-bSpeed, bulletRB.velocity.y);
            bulletRB.transform.localScale = new Vector3(0.004707938f, 0.001673524f, 1);
            bulletRB.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
