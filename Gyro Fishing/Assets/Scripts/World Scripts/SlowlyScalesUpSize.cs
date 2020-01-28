using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyScalesUpSize : MonoBehaviour
{
    public float scaleSpeed;
    public float scaleLimit;

    void Update()
    {
        if (transform.localScale.x < scaleLimit)
            transform.localScale = new Vector3(transform.localScale.x * scaleSpeed, transform.localScale.y * scaleSpeed, transform.localScale.z * scaleSpeed);

    }
}
