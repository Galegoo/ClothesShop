using UnityEngine;
using UnityEngine.UI;

public class UiMuteButton : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        FindObjectOfType<Music>().Mute();
    }
}
