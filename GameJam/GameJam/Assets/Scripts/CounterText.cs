using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class CounterText : MonoBehaviour
{
    public float Speed;
    public TextMeshProUGUI TextObject;

    public float Current;

    public void Update()
    {
        Current = Mathf.Lerp(Current, Player.Instance.Score * 100, Speed * Time.fixedDeltaTime);
    }

    private void OnGUI()
    {
        TextObject.text = Current.ToString("0000000");
    }


}
