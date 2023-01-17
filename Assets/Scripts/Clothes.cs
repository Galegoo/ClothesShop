using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField] string _description;
    [SerializeField] string _name;
    [SerializeField] int _price;

    public string getDescription ()
    {
        return _description;
    }
    public string getName()
    {
        return _name;
    }
    public int getprice()
    {
        return _price;
    }
}
