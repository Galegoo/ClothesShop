using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// Class to flahs objects
/// </summary>
public class FlashObject : MonoBehaviour
{
    private  Canvas flashing_Label;

    [SerializeField] float interval;

    void Start()
    {
        flashing_Label = GetComponent<Canvas>();
        InvokeRepeating("FlashLabel", 0, interval);
    }

    void FlashLabel()
    {
        if (flashing_Label.enabled == true)
            flashing_Label.enabled = false;
        else
            flashing_Label.enabled = true;
    }
}
