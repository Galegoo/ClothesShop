using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

/// <summary>
// Text animation
/// </summary>
public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;

   [SerializeField] string message;
   [SerializeField] TMP_Text textComp;

    // Use t$$anonymous$$s for initialization
    void OnEnable()
    {
        textComp = GetComponent<TMP_Text>();
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}