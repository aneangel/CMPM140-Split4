using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && GameManager.instance.playerHasKeyStatus() == true){
            GameManager.instance.gameOver(true);
        }
    }
}