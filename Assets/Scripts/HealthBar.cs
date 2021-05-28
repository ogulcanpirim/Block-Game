using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject bar;
    private GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void Update()
    {
        
    }
}
