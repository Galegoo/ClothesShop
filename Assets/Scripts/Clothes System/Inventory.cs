using UnityEngine;

/// <summary>
// Inventory data and displayer
/// </summary>
public class Inventory : MonoBehaviour
{

    public GameObject[] positions;
    public int counter;
    public GameObject inventory;
    public GameObject[] inventoryObj;
    [SerializeField] AudioSource clickSound;

    public void DrawInventory()
    {
        positions = GameObject.FindGameObjectsWithTag("positions");
        counter = 0;

        for (int i = 0; i < inventoryObj.Length; i++)
        {
            GameObject inventoryGO = Instantiate(inventoryObj[i], inventory.transform);
            inventoryGO.transform.position = positions[counter].transform.position;
            counter++;
        }
    }

    public void AddToInventoryArray(GameObject obj)
    {
        inventoryObj[counter] = obj;
        counter++;
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
