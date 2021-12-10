using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private int m_Highscore = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            m_Highscore = PlayerPrefs.GetInt("Highscore");
        }

        this.GetComponent<TextMeshProUGUI>().text = "Highscore: " + (m_Highscore * 100).ToString("0000000");
    }
}