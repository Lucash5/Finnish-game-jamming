using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            source.PlayOneShot(clip);
            collision.gameObject.GetComponent<PlayerVitalSigns>().healthtaken(25);
            Destroy(health);
        }
    }
}
