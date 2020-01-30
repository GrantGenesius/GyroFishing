using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyScalesUpSize : MonoBehaviour
{
    public float scaleSpeed;
    public float scaleLimit;
    public float currentTime;
    public float deadTime;

    private void Start()
    {
        currentTime = 0;
        deadTime = 105f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>= deadTime)
        {
            Destroy(gameObject);
        }
        if (transform.localScale.x < scaleLimit)
            transform.localScale = new Vector3(transform.localScale.x * scaleSpeed, transform.localScale.y * scaleSpeed, transform.localScale.z * scaleSpeed);

    }
}
