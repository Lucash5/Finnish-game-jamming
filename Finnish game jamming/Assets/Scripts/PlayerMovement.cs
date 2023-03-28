using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float realSPeed;
    public float speed = 350;
    public float sprintSpeed = 650;
    public float jumpForce = 350;
    public AudioClip jumpsound;
    Animator anim;
    AudioSource AS;

    Vector3 playerInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walkspeed();
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(idling());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(walking());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(running());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(pistolrunning());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(pistolwalking());
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(pistoljump());
        }

        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
                AS.PlayOneShot(jumpsound, 0.5f);
            }
        }
    }

    IEnumerator walking()
    {
        realSPeed = speed;

        anim.Play("Walking");
        yield return new WaitForSeconds(0);
    }
    IEnumerator idling()
    {

        anim.Play("Idle");
        yield return new WaitForSeconds(0);
    }
    IEnumerator running()
    {
        realSPeed = sprintSpeed;
        anim.Play("Fast Run");
        yield return new WaitForSeconds(0);
    }
    IEnumerator pistolrunning()
    {
        realSPeed = sprintSpeed * 0.7f;
        anim.Play("Pistol Run");
        yield return new WaitForSeconds(0);
    }
    IEnumerator pistolwalking()
    {
        realSPeed = speed * 0.7f;
        anim.Play("Pistol Walk Import Setting");
        yield return new WaitForSeconds(0);
    }
    IEnumerator pistoljump()
    {
        anim.Play("Pistol Jump");
        yield return new WaitForSeconds(0);
    }

    private void walkspeed()
    {

        playerInput = transform.forward * Input.GetAxis("Vertical") * realSPeed;
        playerInput += transform.right * Input.GetAxis("Horizontal") * realSPeed;
        playerInput.y = rb.velocity.y;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = playerInput;
        }
    }

}
