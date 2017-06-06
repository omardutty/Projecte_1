using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalaEnemy1 : MonoBehaviour
{

    public Scene Already;
    public GameObject player;
    private Transform playerTrans;
    public GameObject enemy;
    private Transform enemyTrans;
    private Rigidbody2D bulletRB;
    public GameObject Izq;
    public GameObject Der;
    public bool IsDead = false;

    public float bulletSpeed;


    void Awake()
    {
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerEnemy>().gameObject;
    }

    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "escenari")
            Destroy(gameObject);
        else if (collision.tag == "Player")
        {
            respawnear();
            Destroy(gameObject); // destruye la bala           
            SceneManager.LoadScene("DeathScene");
            // player.transform.position= new Vector3(-2, -0.86f, 1); // aqui cargamos la escena 

        }
    }

    void respawnear()
    {

        PlayerPrefs.SetString("AlreadyScene", SceneManager.GetActiveScene().name);

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
