using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public Vector3 respawnCod1;

    public bool respawn;

    public GameObject player;
    void Start()
    {
        //player.transform.position = new Vector3(respawnCod1.x,respawnCod1.y,respawnCod1.z);
    }

    void Update()
    {
        if (player.GetComponent<PlayerMovement1>().dead == true) {
            player.transform.position = new Vector3(respawnCod1.x,respawnCod1.y,respawnCod1.z);
            player.GetComponent<PlayerMovement1>().dead = false;
        }
    }
}
