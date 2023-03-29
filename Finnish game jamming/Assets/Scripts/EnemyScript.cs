using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAi : MonoBehaviour
{
    public AudioClip firesound;
    public AudioSource source;
    public GameObject witch;
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

        if (isMove == true && haltallanim == false)
        {
            GreenMail();
        }
    }

    private void GreenMail()
    {
        //targetPosition = objB.transform.position; // Get position of object B
        //currentPosition = this.transform.position; // Get position of object A
        directionOfTravel = targetPosition - currentPosition;
        if (Vector3.Distance(currentPosition, targetPosition) > .1f && Vector3.Distance(currentPosition, targetPosition) < 75 && haltallanim == false)
        {
            if (haltanim == false)
            {
                anim.Play("Walking", 0, 0f);
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
}

