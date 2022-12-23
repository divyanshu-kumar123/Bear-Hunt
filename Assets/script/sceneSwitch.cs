using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSwitch : MonoBehaviour
{

    public Canvas mainCanvas, optionCanvas;
    public Button level1btn, level2btn, level3btn;
    //method to switch scene
    public void gameSceneSwitch()
    {
        SceneManager.LoadScene(1);
    }
    public void menuSceneSwitch()
    {
        SceneManager.LoadScene(0);
    }
    public void optionMenuToggle()
    {
        mainCanvas.gameObject.SetActive(false);
        optionCanvas.gameObject.SetActive(true);
    }
    public void mainMenuToggle()
    {
        mainCanvas.gameObject.SetActive(true);
        optionCanvas.gameObject.SetActive(false);
    }
    public void invertControl()
    {
        cameraMovement.isInvert = true;
    }

    public void TPPmode()
    {
        cameraMovement.FPP = false;
    }
    public void FPPmode()
    {
        cameraMovement.FPP = true;
    }
    public void exitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        //if (levelUnlock.levelUnlocked >= 4)
        //{
        //    restartButton.interactable = false;
        //}
        level1btn.interactable = false;
        level2btn.interactable = false;
        level3btn.interactable = false;

    }
    private void Update()
    {
        if(levelUnlock.levelUnlocked == 1)
        {
            level1btn.interactable = true;
            level2btn.interactable = false;
            level3btn.interactable = false;
        }else if(levelUnlock.levelUnlocked ==2)
        {
            level1btn.interactable = true;
            level2btn.interactable = true;
            level3btn.interactable = false;
        }
        else if (levelUnlock.levelUnlocked >= 3)
        {
            level1btn.interactable = true;
            level2btn.interactable = true;
            level3btn.interactable = true;
        }
    }

    public void CurrentLevelSet1()
    {
        levelUnlock.levelUnlocked = 1;
    }    
    public void CurrentLevelSet2()
    {
        levelUnlock.levelUnlocked = 2;
    } 
    public void CurrentLevelSet3()
    {
        levelUnlock.levelUnlocked = 3;
    }

}
