using UnityEngine;
using TMPro;

public class GoalTrigger2D : MonoBehaviour
{
    public TMP_Text winText;
    public AudioClip winSound; 

    private AudioSource audioSource;

    void Start()
    {
        winText.text = "";

        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weight"))
        {
            winText.text = "You Win!";

            if (winSound != null)
            {
                audioSource.PlayOneShot(winSound); 
            }

            PauseManager.Instance.ShowWinScreen(); 
        }
    }
}


