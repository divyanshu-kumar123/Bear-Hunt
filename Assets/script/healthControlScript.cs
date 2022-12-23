using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class healthControlScript : MonoBehaviour
{
    public static TMP_Text healthText;
    public static int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
