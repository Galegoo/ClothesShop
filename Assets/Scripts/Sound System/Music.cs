using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
// Music Class that transpass scenes
/// </summary>
public class Music : MonoBehaviour
{
    public AudioSource trilha;
    public bool soundIsOn;
    public GameObject sounds;
    public GameObject soundsButton;
    Scene ActiveScene;
    int counter;
    int sceneCounter;

    private static Music instance = null;


    public static Music Instance
    {
        get { return instance; }
    }


    void Awake()
    {
        trilha = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            if (instance.trilha.clip != trilha.clip)
            {
                instance.trilha.clip = trilha.clip;
                instance.trilha.volume = trilha.volume;
                instance.trilha.Play();
            }

            Destroy(this.gameObject);
            return;
        }
        instance = this;

        trilha.Play();

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        soundIsOn = true;
        sceneCounter = 0;    
    }


    void Update()
    {
        ActiveScene = SceneManager.GetActiveScene();
        if (ActiveScene.name == "Store" && sceneCounter < 1)
        {
            sounds = GameObject.Find("SoundClips");
            soundsButton = GameObject.Find("Sound Button");
            sceneCounter++;
            sounds.SetActive(soundIsOn);
            if (!soundIsOn)
            {
                soundsButton.GetComponent<Image>().enabled = false;
                soundsButton.transform.GetChild(0).gameObject.SetActive(true);
            }
           
        }
        if (soundIsOn == false)
        {
            trilha.mute = true;
        }
        else
        {
            trilha.mute = false;
        }
    }


    public void Mute()
    {
        if (counter < 1)
        {
            soundIsOn = false;
            sounds.SetActive(false);
            soundsButton.GetComponent<Image>().enabled = false;
            soundsButton.transform.GetChild(0).gameObject.SetActive(true);
            counter++;
        }
        else
            UnMute();

    }
    public void UnMute()
    {
        soundIsOn = true;
        sounds.SetActive(true);
        soundsButton.GetComponent<Image>().enabled = true;
        soundsButton.transform.GetChild(0).gameObject.SetActive(false);
        counter = 0;
    }
}
