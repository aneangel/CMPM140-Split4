using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider){ //Set player has key to true
        if(collider.gameObject.tag == "Player"){
            GameManager.instance.playerHasKeyTrue();
            this.gameObject.SetActive(false);
        }
    }
}
