using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] BalasSprites;

    public Image BalasUI;

    private PlayerEnemy Player;

    void Start (){

       // Player = GameObject.FindGameObjectsWithTag("Jugador").GetComponent<Player>();
    }

    void Update(){

       // BalasUI.sprite = BalasSprites[Player.curBalas];
    }


}
