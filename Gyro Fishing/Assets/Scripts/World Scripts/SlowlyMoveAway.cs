using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyMoveAway : MonoBehaviour
{
    private GameObject target;
    public float moveSpeed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -moveSpeed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //object destruction
        if (col.gameObject.tag == "sky")
        {
            Destroy(gameObject);
        }
    }

}
