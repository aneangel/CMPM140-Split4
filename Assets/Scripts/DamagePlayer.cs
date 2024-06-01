using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Transform player1SpawnPoint, player2SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.playReviveSound(); //Playing Audio
            ParticleManager.instance.playDeathParticles(other.gameObject.transform.position);
            RespawnManager.instance.respawnPlayers();
        }
        
    }
}
