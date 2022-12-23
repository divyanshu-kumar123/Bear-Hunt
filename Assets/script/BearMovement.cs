using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BearMovement : MonoBehaviour
{
    public Animator                 bearAnimator;
    public Animator                charAnimator;
    public float                         rotationSpeed, movementSpeed;                                                                         //for random movement
    private bool                        isWalking, isRotatingLeft, isRotatingRight, isMoving;                                         //for random movement
    public GameObject         character;
    public TMP_Text                healthTMP;
    public TMP_Text                scoreTMP;
    public static int                 score = 0;
    private int                           health;
    public bool                         isAlive = true;
    public AudioSource         bearAttackAudio;
    public static bool             isCharAlive = true;


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
        isAlive = true;
    }

    void Update()
    {
        scoreTMP.text = "Score  :  " + BearMovement.score;
        if (isMoving == false)
        {
            StartCoroutine(randomMove());
        }
        if (isRotatingLeft == true && isAlive)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            bearAnimator.SetBool("WalkForward", true);
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
        if (isRotatingRight && isAlive)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            bearAnimator.SetBool("WalkForward", true);
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
        if (isWalking == true && isAlive)
        {
            transform.Translate(0, 0, 1* Time.deltaTime* movementSpeed);
            bearAnimator.SetBool("WalkForward", true);      
        }
        else
        {
            bearAnimator.SetBool("WalkForward", false);
        }
      
        if(Vector3.Distance(transform.position, character.transform.position) <= 3f && isAlive)
        {
            transform.LookAt(character.transform);
        }
    }
    IEnumerator randomMove()
    {
        //                                                                            *********** Random Movement *******************
        //getting some random value
        int rotatingTime = Random.Range(1, 3);                                        //for rotating
        int rotatePause = Random.Range(1, 3);                                         //stop rotating
        int rotateDirection = Random.Range(1, 2);                                   //to get the direction of rotating
        int walkingTime = Random.Range(1, 3);                                         //for walking
        int walkPause = Random.Range(1, 5);                                             //stop walking
        isMoving = true;
        yield return new WaitForSeconds(walkingTime);                        //Walking after "walkingTime" Second

        isWalking = true;
        yield return new WaitForSeconds(walkPause);                            //Stopping after "walkPause" Seconds
        isWalking = false;

        yield return new WaitForSeconds(rotatingTime);                        //Rotating after "rotatingTime
        if (rotateDirection == 1 )                                                                        //for ranadomly getting the direction of rotation
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
        if(collision.gameObject != character)
        {
            isWalking = false;
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }

        if(collision.gameObject == character && isCharAlive && isAlive)
        {
            bearAnimator.SetBool("Attacks", true);
            bearAnimator.SetBool("WalkForward", false);
            charAnimator.SetBool("GetHit", true);
            bearAttackAudio.Play();
            healthControl(100);
            healthTMP.text = "Health  :  " + health;
            isCharAlive = false;
        }
    }


    public void healthControl(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isCharAlive = false;
            health = 0;
            StartCoroutine(afterDeath());
        }
    }
        IEnumerator afterDeath()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
