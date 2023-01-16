using UnityEngine;
using TMPro;

public class MoneyVerifier : MonoBehaviour
{
    public static int money;
    [SerializeField] TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        money = 250;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "" + money;
    }
}
