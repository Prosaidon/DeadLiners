using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Mulai()
    {
        SceneManager.LoadScene("Mulai");
    }

    public void Keluar()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    
}
