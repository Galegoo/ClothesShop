using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.anyKey && count <1)
        {
            GetComponent<Animator>().enabled = true;
            count++;
        }
    }
}
