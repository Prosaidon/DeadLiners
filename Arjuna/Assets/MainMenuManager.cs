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
    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void Keluar()
    {
        SceneManager.LoadScene("Keluar");
    }
}
