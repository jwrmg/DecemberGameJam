using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandlerLoader : MonoBehaviour
{
    public VerticalLayoutGroup Group;

    public PowerupRenderer Template;

    public void Start()
    {
        PowerUpHandler.Instance.Group = Group;
        PowerUpHandler.Instance.Template = Template;
    }
}