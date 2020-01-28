using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyMoveTowards : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float bigboatTime;
    public float smolboatTime;
    private float timeCounter = 0;
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("target");
        if (gameObject.tag == "bigboat" || gameObject.tag == "smolboat")
        {
            sr.sortingOrder = -2;
            moveSpeed *= -1;
        }
    }

    void Update()
    {
        //time counter update for sorting order and movement direction
        if (gameObject.tag == "bigboat") {
            if (timeCounter > bigboatTime && moveSpeed < 0)
            {
                sr.sortingOrder = 2;
                moveSpeed *= -1;
            }
            else
            {
                timeCounter += Time.deltaTime;
            }
        }
        else if (gameObject.tag == "smolboat")
        {
            if (timeCounter > smolboatTime && moveSpeed < 0)
            {
                sr.sortingOrder = 2;
                moveSpeed *= -1;
            }
            else
            {
                timeCounter += Time.deltaTime;
            }
        }

        //object movement
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        SlowlyGainMoveSpeed();
    }

    void SlowlyGainMoveSpeed() {
        moveSpeed += 0.0001f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //object destruction
        if (col.gameObject.tag == "target")
        {
            Destroy(gameObject);
        }
    }

}
