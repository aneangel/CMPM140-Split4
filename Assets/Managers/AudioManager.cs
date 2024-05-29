using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource player1Source, player2Source, fallZoneSource;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void player1Jump(){
        player1Source.Play();
    }

    public void player2Jump(){
        player2Source.Play();
    }

    public void playReviveSound(){
        fallZoneSource.Play();
    }
}
