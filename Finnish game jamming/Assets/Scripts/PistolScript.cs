using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    private bool Startt = false;

    private bool canreload = true;
    public Camera camera;
    public MeshRenderer gunenabled;
    public AudioClip firesound;
    public AudioSource source;
    public ParticleSystem firePs;
    public float fireRate = 0.1f;
    public GameObject prefab;
    public Transform firePoint;
    public float bulletForce = 0.1f;
    public int bulletamount = 225;
    public int bulletCount = 9;
    public int damage = 30;
    public float reloadTime = 2f;
    public AudioClip reloadsound;

    bool reloading;
    int maxBulletCount;
    bool isOnCD = false;

    // Start is called before the first frame update
    void Start()
    {
        maxBulletCount = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletamount <= 0)
        {
            canreload = false;
        }
        button.onClick.AddListener(gameon);
        if (Startt == true)
        {

            if (gunenabled.enabled == true)
        {

        StartCoroutine(GunFire());
            if (Input.GetKeyDown(KeyCode.R) && canreload == true)
            {
                reloading = true;
                source.PlayOneShot(reloadsound);
                Invoke("Reload", reloadTime);
            }
        }
        }
    }
    IEnumerator GunFire()
    {
        //GetMouseButton
        if (Input.GetMouseButtonDown(0) && !isOnCD && reloading == false && bulletCount != 0)
        {
            //bulletCount <= 0
            isOnCD = true;
            Invoke("ResetFireCD", fireRate);
            firePs.Play();
            source.PlayOneShot(firesound);

            RaycastHit hit;
            Ray ray = new Ray(firePoint.transform.position, firePoint.transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.GetComponent<EnemyAi>())
                {
                    objectHit.GetComponent<EnemyAi>().TakeDamage(damage);
                }
                
            }
            bulletCount--;


            GameObject newBullet = Instantiate(prefab, firePoint.position, firePoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletForce);
            yield return new WaitForSeconds(1);
            Destroy(newBullet);

        }
    }

    void Reload()
    {
        reloading = false;
        bulletCount = maxBulletCount;
    }

    void ResetFireCD()
    {
        isOnCD = false;
    }

    private void gameon()
    {
        Startt = true;
    }

    public void refill(int ammo)
    {
        bulletamount += ammo;
        canreload = true;
    }
}
