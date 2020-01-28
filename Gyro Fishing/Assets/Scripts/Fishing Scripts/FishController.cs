using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float timer;
    public float timeToGo;
    public float timeTolerance;
    public FishingRodController frc;
    public int scoreGain;

    public bool isOnBait;

    

    public SpriteRenderer srSelf;
    void Start()
    {
        srSelf = gameObject.GetComponent<SpriteRenderer>();
        frc = FindObjectOfType<FishingRodController>();
        timer = 0;
        timeToGo = Random.Range(7, 10);
        timeTolerance = Random.Range(1, 3);

    }

        void Update()
    {
        if (isOnBait)
        {
            timer += Time.deltaTime;
            srSelf.color = Color.red;
        }
        else
        {
            timer = 0;
        }

        LevelOfEatBait();
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == gameObject.tag){
            frc.fishInBait = gameObject;
            isOnBait = true;
            
        }
        if(collision.tag != gameObject.tag)
        {
           if(frc.lemparBody.velocity.x <= 1 && frc.lemparBody.velocity.y <= 1)
            {
                isOnBait = false;
                frc.PullBack();
            }
            

            
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == gameObject.tag)
        {
            srSelf.color = Color.black;
            isOnBait = false;
            frc.fishInBait = null;
        }
    }

    public void Shaking(float shakeRadius)
    {
        gameObject.transform.position = new Vector2(transform.position.x - shakeRadius, transform.position.y);
        shakeRadius = -shakeRadius;
    }

    public void LevelOfEatBait()
    {
        if (timer < timeToGo - timeTolerance)
        {
            //srSelf.color = Color.green;


        }

        if (timer >= timeToGo - timeTolerance && timer < timeToGo)
        {
            srSelf.color = Color.yellow;
            frc.isReadyToPull = false;
        }

        if (timer >= timeToGo && timer < timeToGo + timeTolerance)
        {
            srSelf.color = Color.green;
            frc.isReadyToPull = true;
        }

        if (timer > timeToGo + timeTolerance)
        {
            Destroy(gameObject);
        }
    }
}
