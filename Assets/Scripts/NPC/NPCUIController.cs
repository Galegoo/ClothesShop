using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

/// <summary>
// Deals with Npc interaction, bying and selling items
/// </summary>
public class NPCUIController : MonoBehaviour
{

    [SerializeField] GameObject baloonsCanvas;
    [SerializeField] GameObject pressEtoInteractCanvas;
    [SerializeField] int index;
    [SerializeField] GameObject arrowBuy;
    [SerializeField] GameObject arrowSell;
    [SerializeField] GameObject arrowExit;
    [SerializeField] GameObject SellInventory;
    [SerializeField] GameObject BuyInventory;
    [SerializeField] Inventory inventoryRef;

    static bool _isNPCActive;
    public static bool isNpcActive { get { return _isNPCActive; } set { _isNPCActive = value; } }

    public enum NpcState { Selling, Buying, NpcOffState }
    public static NpcState state;

    public static GameObject clotheSelected;

    [SerializeField] GameObject[] positions;
    [SerializeField] GameObject[] positionsbuy;
    [SerializeField] GameObject[] allClothestoBuy;
    [SerializeField] GameObject objectssell;
    [SerializeField] GameObject objectsbuy;
    [SerializeField] TMP_Text moneySellText;
    [SerializeField] TMP_Text moneyBuyText;
    [SerializeField]TMP_Text warningText;

    int contador;
    int timesBuyWasOpen;
    int timesNpcWasOpen;

    static bool _isSellOrBuyOn;

    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource SellSound;
    [SerializeField] AudioSource BuySound;

    // Start is called before the first frame update
    void Start()
    {
        pressEtoInteractCanvas.SetActive(false);
        index = 1;
        state = NpcState.NpcOffState;
        timesNpcWasOpen = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        _isNPCActive = baloonsCanvas.activeSelf;

        if (baloonsCanvas.activeSelf)
        {
            switch (index)
            {
                case 1:
                    arrowBuy.SetActive(true);
                    arrowSell.SetActive(false);
                    arrowExit.SetActive(false);
                    break;
                case 2:
                    arrowSell.SetActive(true);
                    arrowBuy.SetActive(false);
                    arrowExit.SetActive(false);
                    break;
                case 3:
                    arrowExit.SetActive(true);
                    arrowSell.SetActive(false);
                    arrowBuy.SetActive(false);            
                    break;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && index > 1)
            {
                index -= 1;
                if(clickSound != null)
                    clickSound.Play();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && index < 3)
            {
                index += 1;
                if (clickSound != null)
                    clickSound.Play();
            }
            if (!BuyInventory.activeSelf && !SellInventory.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (index)
                    {
                        case 1:
                            OpenPopUp(BuyInventory);
                            state = NpcState.Buying;
                            if (timesBuyWasOpen < 1)
                            {
                                contador = 0;
                                DrawBuy();
                                timesBuyWasOpen++;
                            }
                            break;
                        case 2:
                            OpenPopUp(SellInventory);
                            state = NpcState.Selling;
                            contador = 0;
                            DrawSell();

                            break;
                        case 3:
                            state = NpcState.NpcOffState;
                            PlayerController.changeLimitMovmentStatus(false);
                            pressEtoInteractCanvas.SetActive(false);
                            baloonsCanvas.SetActive(false);
                            index = 1;
                            StartCoroutine(WaitToOpenNpcAgain());
                            break;
                    }
                    if (clickSound != null)
                        clickSound.Play();
                }
            }     
        }
        if (PlayerController.NpcWasTouched) // NPC INTERACTION
        {
            if (!baloonsCanvas.activeSelf)
            {
                pressEtoInteractCanvas.SetActive(true);
            }    
            
            if (Input.GetKeyDown(KeyCode.E) && !baloonsCanvas.activeSelf && timesNpcWasOpen == 0)
            {
                timesNpcWasOpen++;
                PlayerController.changeLimitMovmentStatus(true);
                pressEtoInteractCanvas.SetActive(false);
                baloonsCanvas.SetActive(true);
                arrowSell.SetActive(false);
                arrowExit.SetActive(false);
            }
        }
        else
        {
            pressEtoInteractCanvas.SetActive(false);
            baloonsCanvas.SetActive(false);
        }

        if (state == NpcState.Selling)
        {
            moneySellText.text = "" + MoneyVerifier.money;
        }
        else if(state == NpcState.Buying)
        {
                moneyBuyText.text = "" + MoneyVerifier.money;
        }
    }

    public void AddToBuy(GameObject obj)
    {
        obj.transform.position = positionsbuy[contador].transform.position;
        allClothestoBuy[contador] = obj;
        contador++;
    }

    void DrawBuy()
    {
        for (int i = 0; i < allClothestoBuy.Length; i++)
        {
            GameObject inventoryGO = Instantiate(allClothestoBuy[i], objectsbuy.transform);
            AddToBuy(inventoryGO);
        }
    }

    void DrawSell()
    {
        for (int i = 0; i < inventoryRef.inventoryObj.Length; i++)
        {
            GameObject inventoryGO = Instantiate(inventoryRef.inventoryObj[i], objectssell.transform);
            inventoryGO.transform.position = positions[contador].transform.position;
            contador++;
        }
    }

    void Clean(GameObject _objects)
    {
        GameObject[] allClothes;
        allClothes = new GameObject[_objects.transform.childCount];

        for (int i = 0; i < _objects.transform.childCount-1; i++)
        {     
            allClothes[i] = _objects.transform.GetChild(i+1).gameObject;
        }
        foreach (GameObject go in allClothes )
        {
            if(go != null)
            {
                    Destroy(go);
            }
        }

    }
    void DeleteSelectedItem(GameObject _objects)
    {
        GameObject[] allClothes;
        allClothes = new GameObject[_objects.transform.childCount];

        for (int i = 0; i < _objects.transform.childCount - 1; i++)
        {
            allClothes[i] = _objects.transform.GetChild(i + 1).gameObject;
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

    public void OpenPopUp(GameObject popup)
    {
        popup.SetActive(true);
        PlayerController.changeLimitMovmentStatus(true);
    }
    public void closesell()
    {
        if (clickSound != null)
            clickSound.Play();
        Clean(objectssell);
        SellInventory.SetActive(false);
        clotheSelected = null;

    }

    public void closeBuy()
    {
        if (clickSound != null)
            clickSound.Play();
        BuyInventory.SetActive(false);
        clotheSelected = null;
    }
    public void Buy()
    {;
        if (clotheSelected != null && clotheSelected.GetComponent<Clothes>().Price <= MoneyVerifier.money)
        {
            AddElementToArray(ref inventoryRef.inventoryObj);
            inventoryRef.inventoryObj[inventoryRef.inventoryObj.Length - 1] = clotheSelected;
            MoneyVerifier.money = MoneyVerifier.money - clotheSelected.GetComponent<Clothes>().Price;
            clotheSelected = null;
            if (BuySound != null)
                BuySound.Play();
        }
    }
    public void Sell()
    {    
        if (clotheSelected != null)
        {
            if (!CheckIfItemToBeSelledIsEquiped())
            {
                DeleteSelectedItem(objectssell);
                for (int i = 0; i < inventoryRef.inventoryObj.Length; i++)
                {
                    if (inventoryRef.inventoryObj[i].gameObject.name + "(Clone)" == clotheSelected.name)
                    {
                        Destroy(objectssell.transform.GetChild(i)); //remove from sell
                        RemoveElementFromArray(ref inventoryRef.inventoryObj, i); //remove from inventory

                        if (SellSound != null)
                            SellSound.Play();
                    }
                }
                MoneyVerifier.money = MoneyVerifier.money + (clotheSelected.GetComponent<Clothes>().Price / 2);
                clotheSelected = null;
            }
        }
           
    }
 

    void RemoveElementFromArray<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[i] = arr[i + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }

    void AddElementToArray<T>(ref T[] arr)
    {
        Array.Resize(ref arr, arr.Length + 1);
    }
    IEnumerator WaitToOpenNpcAgain()
    {
        yield return new WaitForSeconds(0.2f);
        timesNpcWasOpen = 0;
    }


        bool CheckIfItemToBeSelledIsEquiped()
    {
        Equip equipRef = FindObjectOfType<Equip>();
        int check = 0;
        for (int i = 0; i < equipRef.equipedItems.Length; i++)
        {
            if (equipRef.equipedItems[i] != null)
            {
                if (clotheSelected.gameObject.tag == equipRef.equipedItems[i].gameObject.tag && clotheSelected.GetComponent<Image>().color == equipRef.equipedItems[i].GetComponent<SpriteRenderer>().color)
                {
                    check++;
                }
            }
        }
        if (check > 0)
        {
            Debug.Log("Equiped, Cant be Selled");
            warningText.gameObject.SetActive(true);
            return true;

        }
        else
        {
            Debug.Log("NotEquiped, Sold");
            return false;
        }
    }
}
