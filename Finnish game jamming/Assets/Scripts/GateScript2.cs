using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript2 : MonoBehaviour
{
    private bool a;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    public void opened(bool open)
    {
        if (open == true)
        {
            StartCoroutine(openn());
        }
    }

    IEnumerator openn()
    {
        if (a == false)
        {
        a = true;
        anim.enabled = true;
        yield return new WaitForSeconds(1);
        anim.enabled = false;
        }
    }
}
