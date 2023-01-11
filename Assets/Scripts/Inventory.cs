using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] posicoes;
    public int contador;
    public GameObject inventory;
    public GameObject[] inventoryObj;

    public Color cor;

    public void Start()
    {
        posicoes = GameObject.FindGameObjectsWithTag("positions");

        for (int i = 0; i < inventoryObj.Length; i++)
        {
            GameObject inventoryGO = Instantiate(inventoryObj[i]);
            AddToInventory(inventoryGO);
        }
    }
    void Update()
    {
    }

    public void AddToInventory(GameObject obj)
    {
        obj.transform.position = posicoes[contador].transform.position;
        inventoryObj[contador] = obj;
        obj.transform.parent = inventory.transform;
        contador++;
    }

    public void inventoryButton()
    {
        cor = GetComponent<SpriteRenderer>().color;
    }
}
