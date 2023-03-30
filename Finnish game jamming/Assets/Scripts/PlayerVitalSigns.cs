using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class PlayerVitalSigns : MonoBehaviour
{
    int modifier = 0;
    public int ammo = 225;
    public int ammo2 = 225;
    public int health = 100;
    public float power = 0;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public MeshRenderer am;
    public MeshRenderer am2;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ()
        {

        }
        
        text.text = health.ToString() + "/100";
        text3.text = power.ToString() + "%";

        if (am.enabled == true)
        {
        text2.text = ammo.ToString();
        }
        else if (am2.enabled == true)
        {
        text2.text = ammo2.ToString();
        }

    }

    public void damagetaken(int damage)
    {
        damage -= modifier;
        health -= damage;
    }

    public void healthtaken(int healthh)
    {
        health += healthh;
        if (health > 100)
        {
            health = 100;
        }
    }

    public void ammotaken(int ammoo)
    {
        if (am.enabled == true)
        {
        ammo += ammoo;
        }
        else if (am2.enabled == true)
        {
            ammo2 += ammoo;
        }
        else
        {
            ammo += ammoo;
        }
    }

    public void ammolost(int ammooo)
    {
        if (am.enabled == true)
        {
            ammo -= ammooo;
        }
        else if (am2.enabled == true)
        {
            ammo2 -= ammooo;
        }

    }


    public void parry(bool parrying)
    {
        if (parrying == true)
        {
            modifier = 3;
        }
        else
        {
            modifier = 0;
        }
    }

    public void energy(float powerr)
    {
        power += powerr;

        if (power > 98)
        {
            power = 100;
        }
    }
}
