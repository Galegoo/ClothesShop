using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    [SerializeField] Color[] colors = { Color.white, Color.black, Color.red, Color.green, Color.blue, Color.gray,  Color.cyan};
    [SerializeField] int colorIndex;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = colors[colorIndex];
    }
}

