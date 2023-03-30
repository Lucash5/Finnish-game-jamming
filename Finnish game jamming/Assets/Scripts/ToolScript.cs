using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public MeshRenderer knifemesh;
    public MeshRenderer gunmesh;
    public MeshRenderer gunmesh1;
    public MeshRenderer gunmesh2;
    public MeshRenderer gunmesh3;
    public MeshRenderer gunmesh4;
    public MeshRenderer gunmesh5;
    public MeshRenderer gunmesh6;
    public MeshRenderer gunmesh7;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            knifemesh.enabled = true;
            gunmesh.enabled = false;
            gunmesh1.enabled = false;
            gunmesh2.enabled = false;
            gunmesh3.enabled = false;
            gunmesh4.enabled = false;
            gunmesh5.enabled = false;
            gunmesh6.enabled = false;
            gunmesh7.enabled = false;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            gunmesh.enabled = true;
            gunmesh1.enabled = true;
            gunmesh2.enabled = true;
            knifemesh.enabled = false;
            gunmesh3.enabled = false;
            gunmesh4.enabled = false;
            gunmesh5.enabled = false;
            gunmesh6.enabled = false;
            gunmesh7.enabled = false;

        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            knifemesh.enabled = false;
            gunmesh.enabled = false;
            gunmesh1.enabled = false;
            gunmesh2.enabled = false;
            gunmesh3.enabled = true;
            gunmesh4.enabled = true;
            gunmesh5.enabled = true;
            gunmesh6.enabled = true;
            gunmesh7.enabled = true;
        }
    }
}
