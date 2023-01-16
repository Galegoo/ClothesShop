using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpActivator : MonoBehaviour
{
    [SerializeField] GameObject inventoryPopUp;
    [SerializeField] Button InventoryButton;
    [SerializeField] Sprite[] inventoryButtonImages;
    int controler;

    // Start is called before the first frame update
    void Start()
    {
        //inventoryPopUp.SetActive(false);
        controler = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !NPCUIController.isNpcOn())
        {
            switch (controler)
            {
                case 0:
                    OpenInventory();
                    PlayerController.changeLimitMovmentStatus(true);             
                    break;

                case 1:
                    CloseInventory();
                    PlayerController.changeLimitMovmentStatus(false);

                    break;
            }

        }
    }

    public void OpenInventory()
    {
        controler++;
        InventoryButton.image.sprite = inventoryButtonImages[controler];
        inventoryPopUp.SetActive(true);
        PlayerController.changeLimitMovmentStatus(true);
        FindObjectOfType<Inventory>().inventoryOn();

    }
    public void CloseInventory()
    {
        inventoryPopUp.SetActive(false);
        controler = 0;
        InventoryButton.image.sprite = inventoryButtonImages[controler];
        PlayerController.changeLimitMovmentStatus(false);
        FindObjectOfType<Inventory>().CleanInventoryHud();
    }
}
