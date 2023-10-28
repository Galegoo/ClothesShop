using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// Delay's the player's animator activations to prevent a bug
/// </summary>
public class DelayToAnimator : MonoBehaviour
{
    int count;    
        // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && count <1)
        {
            GetComponent<Animator>().enabled = true;
            count++;
        }
    }
}
