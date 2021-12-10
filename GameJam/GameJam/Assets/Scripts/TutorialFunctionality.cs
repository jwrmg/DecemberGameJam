using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFunctionality : MonoBehaviour
{
    public GameObject tutMenuUI;
    void Start()
    {
        Time.timeScale = 0f;
        tutMenuUI.SetActive(true);

    }
    void Update()
    {
        
    }
}
