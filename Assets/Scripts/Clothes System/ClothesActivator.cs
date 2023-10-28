using UnityEngine.UI;
using UnityEngine;
using TMPro;

/// <summary>
// Script that is with the prefab clothes icons to send out info to UI
/// </summary>
public class ClothesActivator : MonoBehaviour
{
	// Start is called before the first frame update
	public Button clothesButton;
	[SerializeField] GameObject select;
	public static Color colorstorage;
	public static string gameTag;
	public static string gameName;
	public static string clothesDescription;
	int price;
	TMP_Text priceText;
	TMP_Text descriptionText;
	TMP_Text nameText;


	void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(highlight);
		select = GameObject.Find("select");

		price = GetComponent<Clothes>().Price;
		clothesDescription = GetComponent<Clothes>().Description;
	}

    void highlight()
	{
		select.transform.position = transform.position;
		colorstorage = GetComponent<Image>().color;
		gameName = gameObject.name;
		gameTag = gameObject.tag;
		GameObject warningText = GameObject.Find("WaningText");
		if (warningText != null)
        {
			warningText.SetActive(false);
        }
		if (NPCUIController.state == NPCUIController.NpcState.Selling)
        {
			NPCUIController.clotheSelected = gameObject;
			Debug.Log(NPCUIController.clotheSelected);
			priceText = GameObject.Find("priceTextSell").GetComponent<TMP_Text>();
			priceText.text = "Price :" + price/2;
        }
		else if (NPCUIController.state == NPCUIController.NpcState.Buying)
		{
			NPCUIController.clotheSelected = gameObject;
			Debug.Log(NPCUIController.clotheSelected);
			priceText = GameObject.Find("priceTextBuy").GetComponent<TMP_Text>();
			priceText.text = "Price :" + price;
		}
        else
        {
			descriptionText = GameObject.Find("ItemDescriptionText").GetComponent<TMP_Text>();
			nameText = GameObject.Find("ItemNameText").GetComponent<TMP_Text>();
			descriptionText.enabled = true;
			nameText.enabled = true;
			descriptionText.text = "" + GetComponent<Clothes>().Description;
			nameText.text = "" + GetComponent<Clothes>().Name;
		}
	}
}

