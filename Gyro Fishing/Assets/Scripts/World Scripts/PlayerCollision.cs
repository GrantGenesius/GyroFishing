using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "bigboat" || col.tag == "smolboat")
        {
            Debug.Log("GameOver");
        }
    }
}
