using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandler : Singleton<PowerUpHandler>
{
    private List<PowerupRenderer> Renderers;

    public VerticalLayoutGroup Group;

    public PowerupRenderer Template;

    public void CreatePowerUpRenderer(PowerUp powerUp)
    {
        GameObject obj = Instantiate(Template.gameObject, Vector3.zero, Quaternion.identity, Group.transform);
        PowerupRenderer powerupRenderer = obj.GetComponent<PowerupRenderer>();

        powerupRenderer.Name = powerUp.Name;
        powerupRenderer.Duration = powerUp.Duration;
        powerupRenderer.Sprite = powerUp.DisplaySprite;

        obj.SetActive(true);

        powerUp.m_PowerupRenderer = powerupRenderer;

        powerupRenderer.Begin();
    }
}