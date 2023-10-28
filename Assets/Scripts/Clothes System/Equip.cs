using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
// Equipment Data and Methods 
/// </summary>
public class Equip : MonoBehaviour
{
    [SerializeField] GameObject full1;
    [SerializeField] GameObject full2;
    [SerializeField] GameObject legs;
    [SerializeField] GameObject top;
    [SerializeField] GameObject full1Equip;
    [SerializeField] GameObject full2Equip;
    [SerializeField] GameObject legsEquip;
    [SerializeField] GameObject topEquip;
    public GameObject[] equipedItems;
    PlayerController _player;
    [SerializeField] AudioSource equipSound;

    private void Start()
    {
        DealWithSceneLoading();
    }

    void DealWithSceneLoading()
    {
        _player = GetComponent<PlayerController>();

        Scene ActiveScene = SceneManager.GetActiveScene();
        if (ActiveScene.name == "Store")
        {
            GameObject PreviousScenePlayer = GameObject.Find("Player_1");
            if (PreviousScenePlayer != null)
            {
                for (int i = 0; i < PreviousScenePlayer.transform.childCount; i++)
                {
                    if (PreviousScenePlayer.transform.GetChild(i).gameObject.activeSelf)
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(true);
                        ClothesActivator.gameTag = PreviousScenePlayer.transform.GetChild(i).gameObject.tag;
                        EquipMethod();
                    }
                }
            }
            Destroy(PreviousScenePlayer);
        }
    }
    public void EquipMethod()
    {
        if (ClothesActivator.gameTag != null)
        {
            if (!CheckIfItIsAlreadyEquiped())
            {
                if (equipSound != null)
                    equipSound.Play();
                if (ClothesActivator.gameTag == "full")
                {
                    legs.SetActive(false);
                    top.SetActive(false);
                    full2.SetActive(false);
                    full1.SetActive(true);
                    legsEquip.SetActive(false);
                    topEquip.SetActive(false);
                    full2Equip.SetActive(false);
                    full1Equip.SetActive(true);
                    full1.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                    full1Equip.GetComponent<Image>().color = ClothesActivator.colorstorage;
                    if (PlayerController.CheckInputX() != 0)
                    {
                        _player.clothesAnimatorController[3].SetFloat("moveX", PlayerController.CheckInputX());
                    }
                    else
                    {
                        _player.clothesAnimatorController[3].SetFloat("moveY", PlayerController.CheckInputY());
                    }
                    equipedItems = new GameObject[1];
                    equipedItems[0] = full1;
                }
                else if (ClothesActivator.gameTag == "full2")
                {
                    legs.SetActive(false);
                    top.SetActive(false);
                    full1.SetActive(false);
                    full2.SetActive(true);
                    legsEquip.SetActive(false);
                    topEquip.SetActive(false);
                    full1Equip.SetActive(false);
                    full2Equip.SetActive(true);
                    if (PlayerController.CheckInputX() != 0)
                    {
                        _player.clothesAnimatorController[2].SetFloat("moveX", PlayerController.CheckInputX());
                    }
                    else
                    {
                        _player.clothesAnimatorController[2].SetFloat("moveY", PlayerController.CheckInputY());
                    }
                    equipedItems = new GameObject[1];
                    equipedItems[0] = full2;
                }
                else if (ClothesActivator.gameTag == "legs")
                {
                    full1.SetActive(false);
                    full2.SetActive(false);
                    legs.SetActive(true);
                    full1Equip.SetActive(false);
                    full2Equip.SetActive(false);
                    legsEquip.SetActive(true);
                    legsEquip.GetComponent<Image>().color = ClothesActivator.colorstorage;
                    legs.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                    if (PlayerController.CheckInputX() != 0)
                    {
                        _player.clothesAnimatorController[1].SetFloat("moveX", PlayerController.CheckInputX());
                    }
                    else
                    {
                        _player.clothesAnimatorController[1].SetFloat("moveY", PlayerController.CheckInputY());
                    }
                    if (!CheckIfTheEquipmentIsARobe())
                    {
                        equipedItems[1] = legs;
                    }
                    else
                    {
                        equipedItems = new GameObject[2];
                        equipedItems[1] = legs;
                        equipedItems[0] = null;
                        top.SetActive(false);
                        topEquip.SetActive(false);
                    }

                }
                if (ClothesActivator.gameTag == "tops")
                {
                    full2.SetActive(false);
                    full1.SetActive(false);
                    top.SetActive(true);
                    full2Equip.SetActive(false);
                    full1Equip.SetActive(false);
                    topEquip.SetActive(true);
                    top.GetComponent<SpriteRenderer>().color = ClothesActivator.colorstorage;
                    topEquip.GetComponent<Image>().color = ClothesActivator.colorstorage;
                    if (PlayerController.CheckInputX() != 0)
                    {
                        _player.clothesAnimatorController[0].SetFloat("moveX", PlayerController.CheckInputX());
                    }
                    else
                    {
                        _player.clothesAnimatorController[0].SetFloat("moveY", PlayerController.CheckInputY());
                    }
                    if (!CheckIfTheEquipmentIsARobe())
                    {
                        equipedItems[0] = top;
                    }
                    else
                    {
                        equipedItems = new GameObject[2];
                        equipedItems[0] = top;
                        equipedItems[1] = null;
                        legs.SetActive(false);
                        legsEquip.SetActive(false);
                    }
                }
            }
            else
            {
                if (equipSound != null)
                    equipSound.Play();
                for (int i = 0; i < equipedItems.Length; i++)
                {
                    if (equipedItems[i] != null)
                    {
                        if (equipedItems[i].gameObject.tag == ClothesActivator.gameTag)
                        {
                           
                            GameObject[] _clothes = { full1, full2, top, legs };
                            GameObject[] _clothesEquipment = { full1Equip, full2Equip, topEquip, legsEquip };
                            for (int a = 0; a < _clothes.Length; a++)
                            {
                                if (equipedItems[i] != null)
                                {
                                    if (equipedItems[i].tag == _clothes[a].tag)
                                    {
                                        _clothes[a].SetActive(false);
                                        _clothesEquipment[a].SetActive(false);
                                        equipedItems[i] = null;
                                    }
                                        
                                }                              
                            }
                        }
                    }
                }
            }
        }
            
    }

    bool CheckIfTheEquipmentIsARobe()
    {
        int check = 0;
        for(int i = 0; i < equipedItems.Length; i++)
        {
            if(equipedItems[i] != null)
            {
                if (equipedItems[i].gameObject.tag == "tops" || equipedItems[i].gameObject.tag == "legs")
                {
                    check++;
                }
            }    
        }
        if(check > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    } 

    bool CheckIfItIsAlreadyEquiped()
    {
        int check = 0;
        for(int i = 0; i < equipedItems.Length; i++)
        {
            if (equipedItems[i] != null)
            {
                if (ClothesActivator.gameTag == equipedItems[i].gameObject.tag && ClothesActivator.colorstorage == equipedItems[i].GetComponent<SpriteRenderer>().color)
                {
                    check++;
                }
            }
        }
        if (check > 0)
        {
            Debug.Log("AlreadyEquiped");
            return true;

        }
        else
        {
            Debug.Log("NotEquiped");
            return false;
        }
    }
}
