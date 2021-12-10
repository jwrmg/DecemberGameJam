using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : Singleton<HealthHandler>
{
    private Stack<GameObject> HealthIcons = new Stack<GameObject>();

    public LayoutGroup Group;

    public GameObject Template;

    public bool AddHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Player.Instance.Lives >= Player.Instance.MaxLives)
                return false;

            GameObject obj = Instantiate(Template.gameObject, Vector3.zero, Quaternion.identity, Group.transform);
            HealthIcons.Push(obj);
            obj.SetActive(true);
            Player.Instance.Lives++;
        }

        return true;
    }

    public void RemoveHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (HealthIcons.Count > 0)
            {
                GameObject obj = HealthIcons.Pop();

                obj.GetComponent<DoScale>().Run(new Vector3(0, 0, 0), 0.1f, () => Destroy(obj));

                if (Player.Instance.Lives > 0)
                    Player.Instance.Lives--;

                if (GameManager.Instance.VerifyLives())
                {
                    break;
                }
            }
        }
    }
}