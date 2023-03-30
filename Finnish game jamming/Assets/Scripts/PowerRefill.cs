using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRefill : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject power;
    public GameObject vital;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            source.PlayOneShot(clip);
            vital.GetComponent<PlayerVitalSigns>().energy(33.3f);
            Destroy(power);
        }
    }
}