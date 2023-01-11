using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUIController : MonoBehaviour
{

    [SerializeField] GameObject baloonsCanvas;
    [SerializeField] GameObject pressEtoInteractCanvas;
    [SerializeField] int index;
    [SerializeField] GameObject arrowBuy;
    [SerializeField] GameObject arrowSell;
    [SerializeField] GameObject arrowExit;

    static bool isNPCActive;
    // Start is called before the first frame update
    void Start()
    {
        pressEtoInteractCanvas.SetActive(false);
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isNPCActive = baloonsCanvas.activeSelf;

        if (baloonsCanvas.activeSelf)
        {
            PlayerController.movedAfterStore = false;
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
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && index < 3)
            {
                index += 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (index)
                {
                    case 1:
                        Debug.Log("BUY");
                        break;
                    case 2:
                        Debug.Log("SELL");
                        break;
                    case 3:
                        PlayerController.changeLimitMovmentStatus(false);
                        pressEtoInteractCanvas.SetActive(false);
                        baloonsCanvas.SetActive(false);
                        break;
                }
            }
        }
        if (PlayerController.GetNpcWasTouched())                    // NPC INTERACTION
        {
            if (!baloonsCanvas.activeSelf)
            {
                pressEtoInteractCanvas.SetActive(true);
            }    
            
            if (Input.GetKeyDown(KeyCode.E) && !baloonsCanvas.activeSelf && PlayerController.movedAfterStore)
            {
                PlayerController.changeLimitMovmentStatus(true);
                pressEtoInteractCanvas.SetActive(false);
                baloonsCanvas.SetActive(true);
                arrowSell.SetActive(false);
                arrowExit.SetActive(false);
                Debug.Log("entrou");
            }
        }
        else
        {
            pressEtoInteractCanvas.SetActive(false);
            baloonsCanvas.SetActive(false);
        }
    }

    public static bool isNpcOn()
    {
        return isNPCActive;
    }
}
