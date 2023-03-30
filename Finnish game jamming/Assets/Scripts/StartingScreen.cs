using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class StartingScreen : MonoBehaviour
{
    public GameObject obj;

    public UnityEngine.UI.Image img;
    public UnityEngine.UI.Image img2;
    public UnityEngine.UI.Image img3;
    public UnityEngine.UI.Image img4;
    public UnityEngine.UI.Image img5;
    public UnityEngine.UI.Image img6;
    public UnityEngine.UI.Image img7;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI btntext;
    public TextMeshProUGUI btntext2;
    public TextMeshProUGUI btntext3;
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    // Start is called before the first frame update
    void Start()
    {
        obj.GetComponent<GameSongs>().song(1);
    }

    // Update is called once per frame
    void Update()
    {
        button3.onClick.AddListener(back);
        button2.onClick.AddListener(controls);
        button.onClick.AddListener(gameson);
        

        
    }
    void controls()
    {
        button3.enabled = true;
        btntext3.enabled = true;
        img3.enabled = true;
        text.enabled = true;
        text2.enabled = true;
        btntext.enabled = false;
        btntext2.enabled = false;
        button.enabled = false;
        button2.enabled = false;
        img.enabled = false;
        img2.enabled = false;
    }

    void gameson()
    {
        obj.GetComponent<GameSongs>().song(2);
        img5.enabled = false;
        text.enabled = false;
        text2.enabled = false;
        btntext.enabled = false;
        btntext2.enabled = false;
        button.enabled = false;
        button2.enabled = false;
        img.enabled = false;
        img2.enabled = false;
        img4.enabled = true;
        text3.enabled = true;
        text4.enabled = true;
        text5.enabled = true;
        text6.enabled = true;
        text7.enabled = true;
        img7.enabled = true;
        img6.enabled = true;

    }

    void back()
    {
        button3.enabled = false;
        btntext3.enabled = false;
        img3.enabled = false;
        text.enabled = false;
        text2.enabled = false;
        btntext.enabled = true;
        btntext2.enabled = true;
        button.enabled = true;
        button2.enabled = true;
        img.enabled = true;
        img2.enabled = true;
    }
}
