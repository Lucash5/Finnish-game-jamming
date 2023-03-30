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
    public int health = 100;
    public float power = 0;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = health.ToString() + "/100";
        text2.text = ammo.ToString();
        text3.text = power.ToString() + "%";

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
        ammo += ammoo;
    }

    public void ammolost(int ammooo)
    {
        ammo -= ammooo;
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
