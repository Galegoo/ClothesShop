using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
// Clothes Data
/// </summary>
public class Clothes : MonoBehaviour
{
    [SerializeField] string _description;
    [SerializeField] string _name;
    [SerializeField] int _price;

    public string Description { get { return _description; } set { _description = value; } }

    public string Name { get { return _name; } set { _name = value; } }

    public int Price { get { return _price; } set { _price = value; } }
}
