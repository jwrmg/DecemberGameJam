using UnityEngine;
using UnityEngine.UI;

public class PowerupRenderer : MonoBehaviour
{
    internal string Name;
    internal float Duration;
    internal Sprite Sprite;

    internal float ElapsedTime;

    public Image TargetGraphic;

    public Image PowerUpImage;

    public bool Running = false;

    public void Render()
    {
        if (TargetGraphic != null)
            TargetGraphic.fillAmount = ElapsedTime / Duration;
    }

    public void Update()
    {
        if (Running)
        {
            if (ElapsedTime > 0)
                ElapsedTime -= Time.deltaTime;
            else
            {
                Running = false;
                Destroy(this.gameObject);
            }
        }
    }

    public void Begin()
    {
        PowerUpImage.sprite = Sprite;

        ElapsedTime = Duration;
        Running = true;
    }
}