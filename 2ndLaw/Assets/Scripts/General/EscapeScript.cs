using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScript : MonoBehaviour {
	void Awake ()
    {
        SceneManager.LoadScene("Game_Main");
    }

}
