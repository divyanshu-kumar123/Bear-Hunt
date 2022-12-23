using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSwitch2 : MonoBehaviour
{
    public Button restartButton;
    public void menuSceneSwitch()
    {
        SceneManager.LoadScene(4);
    }
    public void gameSceneSwitch()
    {
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        if (levelUnlock.levelUnlocked >= 4)
        {
            restartButton.interactable = false;
        }
    }

}
