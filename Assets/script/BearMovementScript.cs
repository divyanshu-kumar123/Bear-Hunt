using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BearMovementScript : MonoBehaviour
{
    //
    public Animator bearAnimator;
    public Animator charAnimator;
    public float rotationSpeed, movementSpeed;                                                                         //for random movement
    private bool isWalking, isRotatingLeft, isRotatingRight, isMoving;                                         //for random movement
    public GameObject character;
    public TMP_Text healthTMP;
    public TMP_Text scoreTMP;
    public static int score = 0;
    private int health;
    public static bool isAlive = true;
    public AudioSource bearAttackAudio;
    public bool isCharAlive = true;


    void Start()
    {
        //Initial all bool will be set to false
        isWalking = true;
        isRotatingLeft = false;
        isRotatingRight = false;
        isMoving = false;
        //providing some speed to movement and rotation
        rotationSpeed = 25f;
        movementSpeed = 1f;
        //score and health
        health = 100;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = "Score  :  " + BearMovement.score;
        if (isMoving == false && isAlive)
        {
            //if (bearRandomMove != null)
            //    bearRandomMove();
            StartCoroutine(randomMove());
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            bearAnimator.SetBool("WalkForward", true);
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
        if (isRotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            bearAnimator.SetBool("WalkForward", true);
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
        if (isWalking == true)
        {
            transform.Translate(0, 0, 1 * Time.deltaTime * movementSpeed);
            bearAnimator.SetBool("WalkForward", true);
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
        //if(isSitting == true)
        //{
        //    bearAnimator.SetBool("Sit", true);
        //}
        //else
        //{
        //    bearAnimator.SetBool("Sit", false);
        //}
        //if(isSleeping == true)
        //{
        //    bearAnimator.SetBool("Sleep", true);
        //}
        //else
        //{
        //    bearAnimator.SetBool("Sleep", false);
        //}

        if (Vector3.Distance(transform.position, character.transform.position) <= 3f)
        {
            transform.LookAt(character.transform);
        }
    }
    IEnumerator randomMove()
    {
        //                                            ***********Random Movement*******************
        //getting some random value
        int rotatingTime = Random.Range(1, 3);                                   //for rotating
        int rotatePause = Random.Range(1, 3);                                   //stop rotating
        int rotateDirection = Random.Range(1, 2);                               //to get the direction of rotating
        int walkingTime = Random.Range(1, 3);                                  //for walking
        int walkPause = Random.Range(1, 5);                                      //stop walking
        //int sitTime = Random.Range(1, 3);
        //int sitPause = Random.Range(20, 30);
        //int isSit = Random.Range(1, 10);
        //int sleepTime = Random.Range(1, 3);
        //int sleepPause = Random.Range(30, 40);
        //int isSleep = Random.Range(1, 10);
        //Debug.Log(isSleep);
        //Debug.Log(isSit);
        isMoving = true;
        yield return new WaitForSeconds(walkingTime);                       //Walking after "walkingTime" Second

        isWalking = true;
        yield return new WaitForSeconds(walkPause);                         //Stopping after "walkPause" Seconds
        isWalking = false;

        // *****************************For Sitting************************************
        //yield return new WaitForSeconds(sitTime);
        //if (isSit == 2)                                                                              //Will sit only if the random value for isSit comes 2
        //{

        //    isSitting = true;
        //    yield return new WaitForSeconds(sitPause);                       //Will stand after SitPause second
        //    isSitting = false;
        //}
        //yield return new WaitForSeconds(sleepTime);
        //if (isSleep == 3)
        //{

        //    isSleeping = true;
        //    yield return new WaitForSeconds(sleepPause);
        //    isSleeping = false;
        //}
        yield return new WaitForSeconds(rotatingTime);                        //Rotating after "rotatingTime
        if (rotateDirection == 1)                                                                //for ranadomly getting the direction of rotation
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotatePause);
            isRotatingLeft = false;
        }
        else if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotatePause);
            isRotatingRight = false;
        }
        isMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.transform.localScale.y > 2)
        //{
        //    bearAnimator.SetBool("Jump", true);                                          //for jumping                                                       
        //    transform.Translate(0, 0, 1f);
        //}
        //else
        //{
        //    bearAnimator.SetBool("Jump", false);
        //}
        if (collision.gameObject != character)
        {
            isWalking = false;
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }


        //if (collision.gameObject.transform.localScale.y < 2)
        //{
        //    //animator.SetBool("WalkForward", false);
        //    bearAnimator.SetBool("Get Hit Front", true);                            //for sleeping
        //}
        if (collision.gameObject == character && isCharAlive)
        {
            //charAnimator.SetBool("isDie", true);


            bearAnimator.SetBool("Attacks", true);
            //bearAnimator.SetTrigger("Attack5");
            charAnimator.SetBool("GetHit", true);
            bearAttackAudio.Play();
            healthControl(100);
            //int attackStyle = Random.Range(1, 5);
            //switch (attackStyle)
            //{
            //    case 1: 
            //        bearAnimator.SetBool("Attack1", true);
            //        charAnimator.SetBool("GetHit", true);
            //        bearAttackAudio.Play();
            //        healthControl(30);
            //        break;
            //    case 2: 
            //        bearAnimator.SetBool("Attack2", true);
            //        charAnimator.SetBool("GetHit", true);
            //        bearAttackAudio.Play();
            //        healthControl(40);
            //        break ;
            //    case 3: 
            //        bearAnimator.SetBool("Attack3", true);
            //        charAnimator.SetBool("GetHit", true);
            //        bearAttackAudio.Play();
            //        healthControl(30);
            //        break ;
            //    case 4: 
            //        bearAnimator.SetBool("Attack5", true);
            //        charAnimator.SetBool("GetHit", true);
            //        bearAttackAudio.Play();
            //        healthControl(50);
            //        break ;
            //    default: 
            //        bearAnimator.SetBool("Attack5", true);
            //        charAnimator.SetBool("GetHit", true);
            //        bearAttackAudio.Play();
            //        healthControl(30);
            //        break ;

            //}
            healthTMP.text = "Health  :  " + health;
            //charAnimator.SetBool("GetHit", false);
            //for attacking

        }
        else
        {
            //charAnimator.SetBool("isDie", true);
            //charAnimator.SetBool("GetHit", false);
        }
    }

    public void healthControl(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //charAnimator.SetBool("isDie", true);
            isCharAlive = false;
            health = 0;

            StartCoroutine(afterDeath());
        }
    }

    IEnumerator afterDeath()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
