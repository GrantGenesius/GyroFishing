using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyOrbitRotationOnSpawn : MonoBehaviour
{

    private GameObject parent;

    void Start()
    {
        //to follow gyro rotation
        parent = GameObject.FindGameObjectWithTag("orbit");
        transform.parent = parent.transform;
    }

}
