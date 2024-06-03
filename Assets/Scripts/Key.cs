using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){ //Set player has key to true
        if(collider.gameObject.tag == "Player"){
            AudioManager.instance.playKeySound();
            GameManager.instance.playerHasKeyTrue();
            this.gameObject.SetActive(false);
        }
    }
}
