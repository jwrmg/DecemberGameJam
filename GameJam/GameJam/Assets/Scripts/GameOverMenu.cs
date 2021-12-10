using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : Singleton<GameOverMenu>
{
    public TextMeshProUGUI ScoreText;

    public void Show()
    {
        ScoreText.text = "Score: " + (Player.Instance.Score * 100).ToString("0000000");

        GetComponent<DoScale>().Run(new Vector3(1, 1, 1), 1
        );
    }

    public void Hide()
    {
        GetComponent<DoScale>().Run(new Vector3(0, 0, 0), 1, () => { SceneManager.LoadScene("Menu"); });
    }
}