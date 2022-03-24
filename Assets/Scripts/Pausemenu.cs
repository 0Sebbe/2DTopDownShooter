using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsWon = false;
    int enemiesLeft;
    int enemiesLeft2;
    int enemiesLeft3;

    public GameObject pauseMenuUI;
    public GameObject winMenuUI;


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("GhostEnemy");
        GameObject[] enemies3 = GameObject.FindGameObjectsWithTag("BomberEnemy");

        enemiesLeft = enemies.Length;
        enemiesLeft2 = enemies2.Length;
        enemiesLeft3 = enemies3.Length;

        if (enemiesLeft == 0 && enemiesLeft2 == 0 && enemiesLeft3 == 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level5"))
        {
            Won();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Won()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
