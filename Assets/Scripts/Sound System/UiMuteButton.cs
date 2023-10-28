using UnityEngine;
using UnityEngine.UI;

/// <summary>
// Class that acess the Music class when another scene is loaded
/// </summary>
public class UiMuteButton : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Mute);
    }
    void Mute()
    {
        FindObjectOfType<Music>().Mute();
    }
}
