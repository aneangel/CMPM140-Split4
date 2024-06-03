using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorInstructions;
    private bool isShowingInstructions;

    void Start(){
        isShowingInstructions = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && GameManager.instance.playerHasKeyStatus() == true){ //End Game if Players have keys
            GameManager.instance.gameOver(true);
            this.gameObject.GetComponent<AudioSource>().Play(); //Play Win SFX
        } else if(collider.gameObject.tag == "Player" && GameManager.instance.playerHasKeyStatus() == false){ //Show instructions if not
            if(isShowingInstructions == false){
                isShowingInstructions = true;
                doorInstructions.SetActive(true);
                StartCoroutine(doorInstructionsOff());
            }
        }
    }

    IEnumerator doorInstructionsOff(){
        yield return new WaitForSeconds(3f); //Deactivate Instructions after 3 seconds
        doorInstructions.SetActive(false);
        isShowingInstructions = false;
    }
}
