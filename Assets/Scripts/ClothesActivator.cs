using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class ClothesActivator : MonoBehaviour
{
	// Start is called before the first frame update
	public Button clothesButton;
	[SerializeField] GameObject select;
	public static Color colorstorage;
	public static string gameTag;
	public static string gameName;
	public int price;
	[SerializeField] TMP_Text priceText;

	void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(highlight);
		select = GameObject.Find("select");
	}

    void highlight()
	{
		select.transform.position = transform.position;
		colorstorage = GetComponent<Image>().color;
		gameName = gameObject.name;
		gameTag = gameObject.tag;

		if (NPCUIController.selling)
        {
			NPCUIController.clotheSelected = gameObject;
			Debug.Log(NPCUIController.clotheSelected);
			priceText = GameObject.Find("priceTextSell").GetComponent<TMP_Text>();
			priceText.text = "Price :" + price/2;
        }
		else if (NPCUIController.buying)
		{
			NPCUIController.clotheSelected = gameObject;
			Debug.Log(NPCUIController.clotheSelected);
			priceText = GameObject.Find("priceTextBuy").GetComponent<TMP_Text>();
			priceText.text = "Price :" + price;
		}
	}
}

