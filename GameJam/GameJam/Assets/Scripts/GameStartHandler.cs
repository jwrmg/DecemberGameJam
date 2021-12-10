using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    private DoScale alpha;

    public void Start()
    {
        alpha = this.GetComponent<DoScale>();
    }

    public void HideTutorialMenu()
    {
        alpha.Hide();
    }
}