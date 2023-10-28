using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
// Close or open the inventory
/// </summary>
public class PopUpActivator : MonoBehaviour
{
    [SerializeField] GameObject inventoryPopUp;
    [SerializeField] Button InventoryButton;
    [SerializeField] Sprite[] inventoryButtonImages;
    int controler;
    [SerializeField] GameObject textDescriptionItem;
    [SerializeField] GameObject textNameItem;

    [SerializeField] AudioSource inventorySound;

    // Start is called before the first frame update
    void Start()
    {
        controler = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfNpcPopUpIsOnToOpenInventory();
    }

    /// <summary>
    // Don't allow the inventory to be oppened and restrict the player's movement if the interaction with the Npc is happening 
    /// </summary>
    void CheckIfNpcPopUpIsOnToOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && !NPCUIController.isNpcActive)
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
        if (!NPCUIController.isNpcActive)
        {
            if (inventorySound != null)
            {
                inventorySound.Play();
            }
            if (controler < 1)
            {
                controler++;
                InventoryButton.image.sprite = inventoryButtonImages[controler];
                inventoryPopUp.SetActive(true);
                PlayerController.changeLimitMovmentStatus(true);
                inventoryPopUp.GetComponentInParent<Inventory>().DrawInventory();
            }
            else
                CloseInventory();
        }    
    }
    public void CloseInventory()
    {
        if(inventorySound != null)
        {
            inventorySound.Play();
        }     
        textNameItem.GetComponent<TMP_Text>().enabled = false;
        textDescriptionItem.GetComponent<TMP_Text>().enabled = false;
        inventoryPopUp.GetComponentInParent<Inventory>().CleanInventoryHud();
        inventoryPopUp.SetActive(false);
        controler = 0;
        InventoryButton.image.sprite = inventoryButtonImages[controler];
        PlayerController.changeLimitMovmentStatus(false);
        ClothesActivator.gameTag = null;
        ClothesActivator.gameName = null;
    }
}
