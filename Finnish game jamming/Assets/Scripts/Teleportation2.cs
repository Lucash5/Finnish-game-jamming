using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation2 : MonoBehaviour
{
    public GameObject obj;
    public Transform player;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.position = target.position;
            obj.GetComponent<GameSongs>().song(2);
        }
    }
}
