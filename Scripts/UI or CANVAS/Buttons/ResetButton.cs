using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ResetScene()
    {
        string Scene2Reload = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Scene2Reload);
        Time.timeScale = 1;
    }
}
