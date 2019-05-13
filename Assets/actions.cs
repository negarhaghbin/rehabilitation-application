using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class actions : MonoBehaviour
{
    public void Arkanoid()
    {
        SceneManager.LoadScene("Scenes/Arkanoidmenu");
    }

    public void ABC()
    {
        SceneManager.LoadScene("Scenes/ABCmenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
