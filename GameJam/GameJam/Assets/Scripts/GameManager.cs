using UnityEngine;
using UnityEngine.Events;

public enum GameStates
{
    Start = 0,
    Playing = 1,
    End = 2
}

public class GameManager : Singleton<GameManager>
{
    public GameStates State = GameStates.Start;

    public DoScale TutorialScreen;

    public UnityEvent OnGameStart;
    public UnityEvent OnLivesAdd;
    public UnityEvent OnLivesLost;
    public UnityEvent OnObjectSpawned;
    public UnityEvent OnGameEnd;

    public void Start()
    {
        if (OnLivesLost == null)
            OnLivesLost = new UnityEvent();
        if (OnLivesAdd == null)
            OnLivesAdd = new UnityEvent();
        if (OnObjectSpawned == null)
            OnObjectSpawned = new UnityEvent();

        AddListeners();

        TutorialScreen.Run();
    }

    public void AddListeners()
    {
        OnLivesAdd?.AddListener(() => VerifyLives());
        OnGameEnd?.AddListener(EndGame);
    }

    public bool VerifyLives()
    {
        if (Player.Instance.Lives <= 0)
        {
            OnGameEnd?.Invoke();
            return true;
        }

        return false;
    }

    public void EndGame()
    {
        State = GameStates.End;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Player.Instance.GetComponent<Rigidbody2D>().AddTorque(1000, ForceMode2D.Impulse);
        Player.Instance.GetComponent<DoScale>().Run(new Vector3(0,0,0), 2.5f, () =>
        {
            GameOverMenu.Instance.Show();
        });
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
        State = GameStates.Playing;
    }
}