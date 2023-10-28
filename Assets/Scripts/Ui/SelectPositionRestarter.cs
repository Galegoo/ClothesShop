using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// Restarts select object position
/// </summary>
public class SelectPositionRestarter : MonoBehaviour
{
    Vector2 initialPosition;
    // Start is called before the first frame update
    void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = initialPosition;
    }
}
