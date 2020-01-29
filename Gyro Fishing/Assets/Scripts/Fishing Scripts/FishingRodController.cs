using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingRodController : MonoBehaviour
{
    public int score;
    public Slider powerBar;
    bool holdingUp;
    public Vector2 startClick;
    public Vector2 endClick;
    public GameObject lempar;
    public Vector3 startLempar;
    public Rigidbody2D lemparBody;
    public float power;
    public string activeBait;
    public GameObject fishInBait;
    public Vector2 sizeBait;
    public Sprite[] AllBait;
    public GameObject BaitUsedBig;
    public GameObject BaitUsedSmall;

    public Vector2 startTouchPosition;
    public Vector2 endTouchPosition;





    public bool isReadyToPull;
    // Start is called before the first frame update
    void Start()
    {
        startLempar = lempar.transform.position;
        sizeBait = lempar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {   Check();
        SwipeDown();

        lemparBody = lempar.GetComponent<Rigidbody2D>();
       
    
        

    }

    public void OnMouseDown()
    {
         
        if (lempar.transform.position == startLempar)
        {
            
            powerBar.gameObject.SetActive(true);
            powerBar.value = 0;
            lemparBody.velocity = new Vector3(0, 0, 0);
            startClick = Input.mousePosition;
        }
       
    }

    private void OnMouseDrag()
    {
        
        if (lempar.transform.position == startLempar)
        {
           PowerFishRod();
        } 
    }

    private void OnMouseUp()
    {

       
            power = powerBar.value;
            endClick = Input.mousePosition;

            float angle = Vector2.Angle(startClick, endClick);

        if(startClick == endClick)
        {
            PullBack();

        }

        if (lempar.transform.position == startLempar)
        {
            lemparBody.AddForce(-(startClick - endClick) * power/10);
        }
        else if(startClick.y > endClick.y)
        {
            lemparBody.AddForce(-(startClick - endClick));
        }
        
        




    }

    public void PowerFishRod()
    {
        print("terpanggil");

        if (holdingUp)
        {
            powerBar.value += Time.deltaTime * 300;
        }
        else
        {
            powerBar.value -= Time.deltaTime * 300;
        }



    }

    public void Check()
    {
        if (powerBar.value <= powerBar.minValue)
        {
            holdingUp = true;
        }

        if (powerBar.value >= powerBar.maxValue)
        {
            holdingUp = false;
        }
    }

    public void BaitChoose(string baitName)
    {   if(lempar.transform.position == startLempar)
        lempar.tag = baitName;
        if(baitName == "smolFish")
        {
            BaitUsedBig.GetComponent<SpriteRenderer>().sprite = AllBait[0];
            BaitUsedSmall.GetComponent<SpriteRenderer>().sprite = AllBait[0];
        }

        if(baitName == "bigFish")
        {
            BaitUsedBig.GetComponent<SpriteRenderer>().sprite = AllBait[1];
            BaitUsedSmall.GetComponent<SpriteRenderer>().sprite = AllBait[1];
        }
    }

    public void PullBack()
    {
        powerBar.gameObject.SetActive(false);
        lemparBody.velocity = new Vector2(0, 0);
        powerBar.value = 0;
        lempar.transform.position = startLempar;
        lempar.transform.localScale = sizeBait;
        if (isReadyToPull && fishInBait != null)
        {
            print("You got " + fishInBait.name);
            score += fishInBait.gameObject.GetComponent<FishController>().scoreGain;
            Destroy(fishInBait);
           // fishInBait = null;
        }
        else if (!isReadyToPull && fishInBait != null)
        {
            print("the " + fishInBait.name + "Got Away");
            Destroy(fishInBait);
            //fishInBait = null;
        }
        fishInBait = null;
        isReadyToPull = false;
        

    }


    public void SwipeDown()
    {

        

            
            
           if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
               startTouchPosition = Input.GetTouch(0).position;

           if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
           {
              endTouchPosition = Input.GetTouch(0).position;
              if (endTouchPosition.y < startTouchPosition.y)
                {
                    PullBack();
                }
                  
           }
            


        
    }
    
}
