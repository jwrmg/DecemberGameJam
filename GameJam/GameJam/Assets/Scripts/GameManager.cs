using UnityEngine.Events;

public enum GameStates
{
    Start = 0,
    Playing = 1,
    End = 2
}

public class GameManager : Singleton<GameManager>
{
    public GameStates State = GameStates.Playing;

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

        OnGameStart?.Invoke();

        AddListeners();
    }

    public void AddListeners()
    {
        OnLivesAdd?.AddListener(VerifyLives);
    }

    public void VerifyLives()
    {
        if (Player.Instance.Lives <= 0)
            OnGameEnd?.Invoke();
    }

    public void EndGame()
    {
        State = GameStates.End;
    }
}