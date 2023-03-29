using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public MeshRenderer knifemesh;
    public MeshRenderer gunmesh;
    public MeshRenderer gunmesh1;
    public MeshRenderer gunmesh2;

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
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            gunmesh.enabled = true;
            gunmesh1.enabled = true;
            gunmesh2.enabled = true;
            knifemesh.enabled = false;
        }
    }
}
