using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class PlayerVitalSigns : MonoBehaviour
{
    int modifier = 0;
    public int health = 100;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = health.ToString() + "/100";
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
}
