using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseLevel : MonoBehaviour
{
    public void loadLevel(string name) {
        SceneManager.LoadScene("Scenes/"+name); 
    }
}
