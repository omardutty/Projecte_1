using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour {
    
        private Transform playerTrans;
        public GameObject balaGO;
        public GameObject player;
        public Rigidbody2D balaRB;
        public float speed;
        private Vector2 direccio;
        //En lugar de tiempo hay que destruirlo con un collider
        void Awake()
        {
            playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            balaRB = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            if (playerTrans.localPosition.x < transform.localPosition.x)
            {
                balaRB.velocity = new Vector2(-speed, balaRB.velocity.y);
                GetComponent<SpriteRenderer>().flipY = true;
                transform.localScale = new Vector3(1, 1, 1);
                balaRB.velocity = direccio * speed;

        }
        else
            {
                balaRB.velocity = new Vector2(speed, balaRB.velocity.y);
                GetComponent<SpriteRenderer>().flipY = true;
                transform.localScale = new Vector3(1, 1, 1);
                balaRB.velocity = direccio * speed;


        }
    }


        void Update()
        {
        //Destruir missic codi gera
        }

        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            Destroy(balaGO);
            //player.transform.position = new Vector3(-2.132999f, -2.132999f, 0);
        
        }
        else if (other)
        {
            //Puede que choque con su propio GO
            Destroy(balaGO);
        }
    }
    public void Inicialize(Vector2 direction)
    {

        this.direccio = direction;


    }

}
