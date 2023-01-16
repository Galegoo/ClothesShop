using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] posicoes;
    public int contador;
    public GameObject inventory;
    public GameObject[] inventoryObj;
    [SerializeField] AudioSource clickSound;

    public void inventoryOn()
    {
        posicoes = GameObject.FindGameObjectsWithTag("positions");
        contador = 0;

        for (int i = 0; i < inventoryObj.Length; i++)
        {
            GameObject inventoryGO = Instantiate(inventoryObj[i], inventory.transform);
            inventoryGO.transform.position = posicoes[contador].transform.position;
            contador++;
        }
    }

    public void AddToInventoryArray(GameObject obj)
    {
        inventoryObj[contador] = obj;
        contador++;
    }

    public void CleanInventoryHudCertainObject()
    {
        GameObject[] allClothes;
        allClothes = new GameObject[inventory.transform.childCount];

        for (int i = 0; i < inventory.transform.childCount - 1; i++)
        {
            allClothes[i] = inventory.transform.GetChild(i + 1).gameObject;
        }
        foreach (GameObject go in allClothes)
        {
            if (go != null)
            {
                if (go.name == NPCUIController.clotheSelected.name)
                    Destroy(go);
            }
        }
    }
    public void CleanInventoryHud()
    {
        GameObject[] allClothes;
        allClothes = new GameObject[inventory.transform.childCount];

        for (int i = 0; i < inventory.transform.childCount - 1; i++)
        {
            allClothes[i] = inventory.transform.GetChild(i + 1).gameObject;
        }
        foreach (GameObject go in allClothes)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }

    }
}
