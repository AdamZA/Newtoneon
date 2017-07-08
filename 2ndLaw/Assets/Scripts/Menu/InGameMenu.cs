using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    public void RestartGame()
    {
        AutoFade.LoadScene("Game_Main", 1, 1, Color.black);
        Time.timeScale = 1;
    }
}
