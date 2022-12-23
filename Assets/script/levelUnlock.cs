using UnityEngine;

public class levelUnlock : MonoBehaviour
{
    public static int levelUnlocked = 1;
    public GameObject level1, level2, level3 ;
    public static void increaseLevel()
    {
        levelUnlocked += 1;
    }
    private void Start()
    {
        targetLevelSwitch();
    }
    public void targetLevelSwitch()
    {
        if (levelUnlocked == 1)
        {
            level1.gameObject.SetActive(true);
            level2.gameObject.SetActive(false);
            level3.gameObject.SetActive(false);
        }
        else if (levelUnlocked == 2)
        {
            level1.gameObject.SetActive(false);
            level2.gameObject.SetActive(true);
            level3.gameObject.SetActive(false);
        }
        else if (levelUnlocked >= 3)
        {
            level1.gameObject.SetActive(false);
            level2.gameObject.SetActive(false);
            level3.gameObject.SetActive(true);
        }

    }
}
