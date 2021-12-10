using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;

    public DoScale ScaleObject;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Paused)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Paused = false;
        ScaleObject.Run(new Vector3(0, 0, 0), 0.3f, () =>
          {
              ScaleObject.gameObject.SetActive(false);
          });
    }

    private void Pause()
    {
        ScaleObject.gameObject.SetActive(true);

        ScaleObject.Run(new Vector3(1, 1, 1), 0.3f, () =>
        {
            Paused = true;
            Time.timeScale = 0f;
        });
    }

    public void LoadMenu(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}