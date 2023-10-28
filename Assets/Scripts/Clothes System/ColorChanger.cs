using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
// Change clothe's colors
/// </summary>
public class ColorChanger : MonoBehaviour
{
    Image _image;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    [SerializeField] Color[] colors = { Color.white, Color.black, Color.red, Color.green, Color.blue, Color.gray,  Color.cyan};
    public int colorIndex;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        _image = GetComponent<Image>();
        _image.color = colors[colorIndex];
    }
}

