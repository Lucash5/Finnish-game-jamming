using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAi : MonoBehaviour
{
    bool isdead = false;
    private bool firingnow = false;
    public AudioClip firesound;
    public AudioSource source;
    public GameObject enemy;
    public float health = 100;
    public float dmg = 10;
    public GameObject player;
    public GameObject prefab;
    public Transform firePoint;
    bool isMove = false;
    bool haltanim = false;
    public bool haltallanim = false;
    float speed = 0.33f;
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

        targetPosition = playerpos.position;
        currentPosition = witchpos.position;
        //isMove = true;
        if (isdead == true)
        {

        anim.Play("Death 0");
        }


        if (isMove == true && haltallanim == false && isdead == false)
        {
            GreenMail();
        }
        else if(isdead == false)
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

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Player")
        {
            isMove = true;
        }
    }

    IEnumerator firing()
    {
        firingnow = true;
        StartCoroutine(firebullet());

        yield return new WaitForSeconds(0.5f);
        firingnow = false;
    }

    IEnumerator firebullet()
    {
        
        for (int i = 0; i < 3; i++)
        {
        source.PlayOneShot(firesound);
        GameObject newBullet = Instantiate(prefab, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletForce);
        yield return new WaitForSeconds(1f);
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
        anim.Play("Death");
        yield return new WaitForSeconds(1.3f);
        isdead = true;
    }
}
