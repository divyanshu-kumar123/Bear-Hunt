using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class charMovementScript : MonoBehaviour
{
    
    private float movement, rotation, rotationMouse, rotationy;
    public float speed;
    public Animator animator;
    private bool crouch;

    void Start()
    {
        speed = 5;
        BearMovement.isCharAlive = true;
        //StartCoroutine(increaseSpeed());                                                                                         //for increasing the speed after every 10 sec
    }
    void Update()
    {

        movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;                                           //getting the vertical axis value 
        rotationMouse = Input.GetAxis("Mouse X") ;                                                                          //getting the horixontal axis value 
        rotation = Input.GetAxis("Horizontal") ;                                                                                   //getting the horixontal axis value 
        rotationy = Input.GetAxis("Mouse Y") ;                                                                                   //getting the horixontal axis value 

        if (BearMovement.isCharAlive)
        {
        transform.Translate(0, 0, movement);                                                                                     //to move the character with respect to WS keys
        transform.Rotate(0, rotationMouse , 0);                                                                                  //to rotate the character with respect to AD keys
        transform.Rotate(0, rotation , 0);                                                                                             //to rotate the character with respect to AD keys
        transform.Rotate(0, rotationMouse , 0);                                                                                  //to rotate the character with respect to AD keys
        }

        if (movement != 0 )
        {
            animator.SetBool("isWalk", true);                                                                                         //setting the animation to walk
        }
        else
        {
            animator.SetBool("isWalk", false);                                                                                       //setting back the animation to idle
        }   

    }
    //IEnumerator increaseSpeed()                                                                                                   //A couroutine to increase the speed after every 10 secs
    //{
    //    yield return new WaitForSeconds(10f);
    //    speed += 1;
    //    StartCoroutine(increaseSpeed());                                                                                                

    //}
}




