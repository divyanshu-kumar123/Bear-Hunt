using UnityEngine;

public class cursorControll : MonoBehaviour
{
    public bool isCursorVisible = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isCursorVisible  == true)
        {
            isCursorVisible = false;
        }else if (Input.GetKeyDown(KeyCode.Escape) && isCursorVisible == false)
        {
            isCursorVisible = true ;
        }

        if (isCursorVisible)
        {
            Cursor.visible = true;
        }
        else if(!isCursorVisible)
        {
            Cursor.visible = false;
        }
    }

}
