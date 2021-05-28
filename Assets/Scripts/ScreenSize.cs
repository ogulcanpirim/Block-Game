using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public static Vector2 screenSize = Vector2.zero;

    void Awake()
    {
        Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenSize = (Vector2) screen;
    }

    void Update()
    {
        
    }
}
