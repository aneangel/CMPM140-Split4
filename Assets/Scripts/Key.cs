using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){ //Set player has key to true
        Debug.Log("Collision Detected!");
        if(collider.gameObject.tag == "Player"){
            Debug.Log("Collision Detected!");
            AudioManager.instance.playKeySound();
            GameManager.instance.playerHasKeyTrue();
            this.gameObject.SetActive(false);
        }
    }
}
