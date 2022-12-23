using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float bearHealth = 100f;
    public Animator bearAnimator;
    public AudioSource getHitAudio;
    private int currentLevel = levelUnlock.levelUnlocked;
    private int calculatedmaxScore;

    private void Start()
    {
        if(currentLevel == 1)
        {
            calculatedmaxScore = 100;
        }else  if(currentLevel == 2)
        {
            calculatedmaxScore = 150;
        }else  if(currentLevel >= 3)
        {
            calculatedmaxScore = 200;
        }

    }

    public void getHit(float amount)
    {
        bearHealth -= amount;
        bearAnimator.SetBool("Get Hit Front", true);
        getHitAudio.Play();

        //BearMovement.isAlive = true;

        if (bearHealth <= 0)
        {
            bearHealth = 0;
            transform.GetComponent<BearMovement>().isAlive = false;
            bearAnimator.SetBool("Death", true);
            //Debug.Log("Death is called" + bearAnimator.GetBool("Death"));
            die();
        }
     }
    void die()
    {
        StartCoroutine(dies());
    }


    IEnumerator dies()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        scoreControl(10);
    }
    void scoreControl(int amount)
    {
        BearMovement.score += amount;
        if (BearMovement.score >= calculatedmaxScore)
        {
            levelUnlock.increaseLevel();
            //Debug.Log(levelUnlock.levelUnlocked);
            SceneManager.LoadScene(3);
        }
    }
}
