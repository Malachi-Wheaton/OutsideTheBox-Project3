using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioClip menuMusic;
    public AudioClip levelMusic;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.volume = 0.5f;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        bool isMenuScene = scene.name == "MainMenuScene" || scene.name == "Instruction" || scene.name == "Credit";

        if (isMenuScene)
        {
            if (audioSource.clip != menuMusic)
            {
                audioSource.clip = menuMusic;
                audioSource.Play();
            }
        }

        else 
        {
            if (audioSource.clip != levelMusic)
            {
                audioSource.clip = levelMusic;
                audioSource.Play();
            }
        }
    }
}





