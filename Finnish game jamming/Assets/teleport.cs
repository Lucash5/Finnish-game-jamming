using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform player, Destination;
    public GameObject playerg;

    // TELEPORT
    void OnTriggerEnter (Collider other){

        if (other.gameObject == playerg) { 
            playerg.SetActive(false); // player t�ytyy olla off,�jotta se pystyy teleporttaamaan
            player.position = Destination.position;
            playerg.SetActive(true);
        }
    }


}
