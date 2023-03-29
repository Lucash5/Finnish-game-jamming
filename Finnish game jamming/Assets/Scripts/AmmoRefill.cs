using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRefill : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject ammo;
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
            collision.gameObject.GetComponent<PistolScript>().refill(35);
            Destroy(ammo);
        }
    }
}
