using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;
   // public AudioClip typeSound1;
   // public AudioClip typeSound2;

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
            //if (typeSound1 && typeSound2)
                //SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}