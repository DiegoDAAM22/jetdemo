using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene("JET");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}