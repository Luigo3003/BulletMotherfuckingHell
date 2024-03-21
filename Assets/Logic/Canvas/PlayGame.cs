using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject CanvasToDeactivate;
    public GameObject UIGame;
    public GameObject PlayerInputs;

    private void Awake()
    {
        PlayerInputs.SetActive(false);
    }
    public void StartGame()
    {
        CanvasToDeactivate.SetActive(false);
        UIGame.SetActive(true);
        PlayerInputs.SetActive(true);
        Time.timeScale = 1f;

    }
}
