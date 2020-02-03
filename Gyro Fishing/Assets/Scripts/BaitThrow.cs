using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitThrow : MonoBehaviour
{
    public bool isPressed;
    public bool isReleased;
    public Rigidbody2D rb;
    public SpringJoint2D sj;
    public float releaseTime= 0.15f;
    public GameObject hook;
    public float maxLength;
    public float minLength;
    public LineRenderer lineRender;
    

    void Start()
    {
        isPressed = false;
        rb.gravityScale = 0;
        lineRender = GetComponent<LineRenderer>();
        
    }

    
    void Update()
    {
        if (isPressed && !isReleased)
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
         
            if (Vector3.Distance(hook.transform.position, mousePosition) > maxLength)
            {
                rb.position = hook.transform.position + (mousePosition-hook.transform.position).normalized * maxLength;
                
            }
            else
            {
                rb.position = mousePosition;
                
            }

           
               
        }
        
        
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
      
    }
    private void OnMouseDrag()
    {
        
    }

    private void OnMouseUp()
    {
       
            isPressed = false;
            rb.isKinematic = false;
            StartCoroutine(Release());
        
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        isReleased = true;
        //this.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
       

            
            isReleased = false;
          
                GetComponent<SpringJoint2D>().enabled = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            //GetComponent<SpringJoint2D>().enabled = false;
            isReleased = true;

        }
    }
}
