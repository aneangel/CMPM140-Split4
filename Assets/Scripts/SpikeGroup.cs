using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGroup : MonoBehaviour
{
    [SerializeField] private GameObject spikeGroup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(activateSpikes());
    }

    IEnumerator activateSpikes(){ // called via StartCoroutine(activateSpikes());
        while(GameManager.instance.getGameOverStatus() == false){ //While not game over
            yield return new WaitForSeconds(1.25f); //Wait 1.5 seconds

            if(!spikeGroup.activeInHierarchy){ //If spikeGroup currently not active, set to active
                spikeGroup.SetActive(true);
            } else{ //Else, deactivate
                spikeGroup.SetActive(false);
            }
        }
    }
}
