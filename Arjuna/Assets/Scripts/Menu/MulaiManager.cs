using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
      public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Boss()
    {
        SceneManager.LoadScene("Boss");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
