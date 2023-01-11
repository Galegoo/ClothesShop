using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpActivator : MonoBehaviour
{
    [SerializeField] GameObject inventoryPopUp;
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
                    inventoryPopUp.SetActive(true);
                    controler++;
                    PlayerController.changeLimitMovmentStatus(true);
                    break;

                case 1:
                    inventoryPopUp.SetActive(false);
                    controler = 0;
                    PlayerController.changeLimitMovmentStatus(false);
                    break;
            }

        }
    }
}
