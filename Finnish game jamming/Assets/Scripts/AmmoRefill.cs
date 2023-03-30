using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRefill : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject ammo;
    public GameObject vital;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            source.PlayOneShot(clip);
            collision.gameObject.GetComponent<PistolScript>().refill(35);
            vital.GetComponent<PlayerVitalSigns>().ammotaken(35);
            Destroy(ammo);
        }
    }
}
