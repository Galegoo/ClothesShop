using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    [SerializeField] GameObject full1;
    [SerializeField] GameObject full2;
    [SerializeField] GameObject legs;
    [SerializeField] GameObject top;
    public GameObject[] equipedItems;

    public void EquipMethod()
    {
        if (ClothesActivator.gameTag != null)
        {
            if (ClothesActivator.gameTag == "full")
            {
                legs.SetActive(false);
                top.SetActive(false);
                full2.SetActive(false);
                full1.SetActive(true);
                full1.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                if(PlayerController.CheckInputX() != 0)
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[3].SetFloat("moveX", PlayerController.CheckInputX());
                }
                else
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[3].SetFloat("moveY", PlayerController.CheckInputY());
                }
            }
            else if (ClothesActivator.gameTag == "full2")
            {
                legs.SetActive(false);
                top.SetActive(false);
                full1.SetActive(false);
                full2.SetActive(true);
                if (PlayerController.CheckInputX() != 0)
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[2].SetFloat("moveX", PlayerController.CheckInputX());
                }
                else
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[2].SetFloat("moveY", PlayerController.CheckInputY());
                }
            }
            else if (ClothesActivator.gameTag == "legs")
            {
                full1.SetActive(false);
                top.SetActive(true);
                full2.SetActive(false);
                legs.SetActive(true);
                legs.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                if (PlayerController.CheckInputX() != 0)
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[1].SetFloat("moveX", PlayerController.CheckInputX());
                }
                else
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[1].SetFloat("moveY", PlayerController.CheckInputY());
                }
            }
            if (ClothesActivator.gameTag == "tops")
            {
                legs.SetActive(true);
                full2.SetActive(false);
                full1.SetActive(false);
                top.SetActive(true);
                top.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                if (PlayerController.CheckInputX() != 0)
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[0].SetFloat("moveX", PlayerController.CheckInputX());
                }
                else
                {
                    FindObjectOfType<PlayerController>().clothesAnimatorController[0].SetFloat("moveY", PlayerController.CheckInputY());
                }
            }
        }
    }
}
