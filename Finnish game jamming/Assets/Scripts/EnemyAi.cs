using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAi : MonoBehaviour
{
    private int dmg = 6;
    int e;
    bool abouttodie = false;
    bool isdead = false;
    private bool firingnow = false;
    public AudioClip firesound;
    public AudioSource source;
    public GameObject enemy;
    public float health = 100;
    public GameObject player;
    public GameObject prefab;
    public Transform firePoint;
    bool isMove = false;
    bool haltanim = false;
    public bool haltallanim = false;
    float speed = 0.23f;
    public float bulletForce = 0.1f;
    public Transform playerpos;
    public Transform witchpos;
    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;
    Animator anim;

    [HideInInspector] public static int witchesRemaining = 0;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        targetPosition = playerpos.position;
        currentPosition = witchpos.position;
    }

    void Update()
    {
        if (Vector3.Distance(currentPosition, targetPosition) < 10)
        {
            isMove = true;
        }

        targetPosition = playerpos.position;
        currentPosition = witchpos.position;
        //isMove = true;
        if (isdead == true && abouttodie == false)
        {

        anim.Play("Death 0");
        }


        if (isMove == true && haltallanim == false && isdead == false && abouttodie == false)
        {
            GreenMail();
        }
        else if(isdead == false && abouttodie == false)
        {
            anim.Play("Rifle Idle");
        }
    }

    private void GreenMail()
    {
        //targetPosition = objB.transform.position; // Get position of object B
        //currentPosition = this.transform.position; // Get position of object A
        directionOfTravel = targetPosition - currentPosition;
        if (Vector3.Distance(currentPosition, targetPosition) > .1f && Vector3.Distance(currentPosition, targetPosition) < 75 && haltallanim == false)
        {
            if (haltanim == false && firingnow == false)
            {
            anim.Play("Firing Rifle");
            StartCoroutine(firing());
            }
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
            Quaternion rotation = Quaternion.LookRotation(directionOfTravel);
            transform.rotation = rotation;
        }
        else
        {
            isMove = false;
        }
    }

    IEnumerator firing()
    {
        firingnow = true;
        StartCoroutine(firebullet());
        e = UnityEngine.Random.Range(1,4);
        yield return new WaitForSeconds(1.5f);
        firingnow = false;
    }

    IEnumerator firebullet()
    {
        
        for (int i = 0; i < e; i++)
        
        {
            yield return new WaitForSeconds(0.03f);

            RaycastHit hit;
            Ray ray = new Ray(firePoint.transform.position, firePoint.transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.GetComponent<PlayerMovement>())
                {
                    objectHit.GetComponent<PlayerVitalSigns>().damagetaken(dmg);
                }

            }

            source.PlayOneShot(firesound);
        GameObject newBullet = Instantiate(prefab, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletForce);
        yield return new WaitForSeconds(0.5f);
        Destroy(newBullet);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && isdead == false)
        {
            StartCoroutine(dead());
            //DIE
        }
    }
    IEnumerator dead()
    {
        abouttodie = true;
        anim.Play("Death");
        yield return new WaitForSeconds(2.35f);
        isdead = true;
        abouttodie = false;
    }
}
