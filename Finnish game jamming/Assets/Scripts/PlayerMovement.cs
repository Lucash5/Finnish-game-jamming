using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    private bool Startt = false;

    private bool isdead;
    public GameObject vital;
    private bool swinging = false;
    public MeshRenderer gunmesh;
    public MeshRenderer knifemesh;
    public MeshRenderer riflemesh;
    Rigidbody rb;
    public float realSPeed;
    public float speed = 350;
    public float sprintSpeed = 650;
    public float jumpForce = 350;
    public AudioClip jumpsound;
    Animator anim;
    public AudioSource AS;
    public AudioClip AC;
    public AudioClip AC2;

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
        button.onClick.AddListener(gameon);
        if (isdead == false)
        {

        if (Startt == true)
        {

        walkspeed();
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Mouse1) && (!knifemesh.enabled == true || !Input.GetKey(KeyCode.Mouse0)) && swinging == false)
        {
            StartCoroutine(idling());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1) && (!knifemesh.enabled == true || !Input.GetKey(KeyCode.Mouse0)) && swinging == false)
        {
            StartCoroutine(walking());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1) && swinging == false)
        {
            StartCoroutine(running());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse1) && (gunmesh.enabled == true || riflemesh.enabled == true) && swinging == false)
        {
            StartCoroutine(pistolrunning());
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse1) && (gunmesh.enabled == true || riflemesh.enabled == true) && swinging == false)
        {
            StartCoroutine(pistolwalking());
        }
        else if (Input.GetKey(KeyCode.Space) && swinging == false)
        {
            StartCoroutine(pistoljump());
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse1) && (gunmesh.enabled == true || riflemesh.enabled == true) && swinging == false)
        {
            StartCoroutine(pistolidle());
        }
        else if (Input.GetKey(KeyCode.Mouse0) && knifemesh.enabled == true && swinging == false)
        {
            StartCoroutine(knifeswing());
        }
        else if (Input.GetKey(KeyCode.Mouse1) && knifemesh.enabled == true && swinging == false)
        {
            StartCoroutine(knifeblock());
        }
        }

        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
                AS.pitch = 1;
                AS.PlayOneShot(jumpsound, 0.5f);
            }
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
    IEnumerator pistolidle()
    {
        anim.Play("Pistol Idle");
        yield return new WaitForSeconds(0);
    }

    IEnumerator knifeswing()
    {
        swinging = true;
        anim.Play("Stable Sword Inward Slash");
        yield return new WaitForSeconds(1f);
        AS.PlayOneShot(AC2);
        yield return new WaitForSeconds(0.3f);
        swinging = false;
    }
    IEnumerator knifeblock()
    {
        vital.GetComponent<PlayerVitalSigns>().parry(true);
        anim.Play("Standing Block Idle");
        yield return new WaitForSeconds(0.1f);
        vital.GetComponent<PlayerVitalSigns>().parry(false);
    }
    IEnumerator firingrifle()
    {
        anim.Play("Firing Rifle");
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
            if (Startt == true)
            {

            rb.velocity = playerInput;
            if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f && !AS.isPlaying)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    AS.pitch = 3f;
                    AS.PlayOneShot(AC);
                }
                else
                {
                AS.pitch = 1.5f;
                AS.PlayOneShot(AC);
                }
            }
            }
        }
    }

    private void gameon()
    {
        Startt = true;
    }

    public void isded(bool tru)
    {
        if (tru == true)
        {
            isdead = true;
        }
        else
        {
            isdead = false;
        }
    }
}
