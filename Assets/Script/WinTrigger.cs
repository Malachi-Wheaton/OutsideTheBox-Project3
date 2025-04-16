using UnityEngine;
using TMPro;

public class GoalTrigger2D : MonoBehaviour
{
    public TMP_Text winText;

    void Start()
    {
        winText.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weight"))
        {
            winText.text = "You Win!";
        }
    }

}
