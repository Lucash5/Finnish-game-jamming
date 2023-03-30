using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehousesong : MonoBehaviour
{
    public GameObject obj;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Playerr")
        {
            obj.GetComponent<GameSongs>().song(4);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Playerr")
        {
            obj.GetComponent<GameSongs>().song(2);
        }
    }
}
