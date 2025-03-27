using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public bool IsPaused = false;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void PauseButtonPosition()
    {
        if (PauseMenu.activeSelf) 
        {
            IsPaused = false;
            FindObjectOfType<EnemyCharacterDetecting>().ShootPermission = false;
            FindObjectOfType<EnemyCharacterDetecting>().IsInstanceRunning = true;
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
        }
        else
        {
            IsPaused = true;
            StopCoroutine(FindObjectOfType<EnemyCharacterDetecting>().Instance);
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }
}
