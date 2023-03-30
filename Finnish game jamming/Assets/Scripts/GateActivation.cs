using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System;

public class GateActivation : MonoBehaviour
{
    public UnityEngine.UI.Image img;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public GameObject obj;
    public GameObject obj2;

    public void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.name == "Player" || col.gameObject.name == "Playerr") && text4.text == "100%")
        {
            obj.GetComponent<GateScript>().opened(true);
            obj2.GetComponent<GateScript2>().opened(true);
            img.enabled = false;
            text.enabled = false;
            text2.enabled = false;
            text3.enabled = false;
        }
        else if (col.gameObject.name == "Player")
        {
            img.enabled = true;
            text.enabled = true;
            text2.enabled = true;
            text3.enabled = true;
        }
    }
}
