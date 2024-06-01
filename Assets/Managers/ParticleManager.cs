using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;
    [SerializeField] private GameObject deathParticleSource;
    [SerializeField] private ParticleSystem deathParticles;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    public void playDeathParticles(Vector2 deathLocation){
        deathParticleSource.transform.position = deathLocation; //Changing position of particle emitter to where player died
        deathParticles.Play(); //Playing particle burst
    }
}
