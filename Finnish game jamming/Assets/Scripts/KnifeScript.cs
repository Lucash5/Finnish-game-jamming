using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public GameObject obj;
    public int damage = 50;
    public MeshRenderer knife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void stab(bool i)
    {
        if (i == true && knife.enabled == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            obj.GetComponent<EnemyAi>().TakeDamage(damage);
        }   
    }
}
