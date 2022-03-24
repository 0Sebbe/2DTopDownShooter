using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextWave : MonoBehaviour
{
    int enemiesLeft;
    int enemiesLeft2;
    int enemiesLeft3;
    Door doorScript;
    public int nextSceneLoad;
    void Start()
    {
        doorScript = GameObject.Find("Door").GetComponent<Door>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneLoad);
            Score.scoreValue+=nextSceneLoad - 5;

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                
            }
        }
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("GhostEnemy");
        GameObject[] enemies3 = GameObject.FindGameObjectsWithTag("BomberEnemy");

        enemiesLeft = enemies.Length;
        enemiesLeft2 = enemies2.Length;
        enemiesLeft3 = enemies3.Length;

        if (enemiesLeft == 0 && enemiesLeft2 == 0 && enemiesLeft3 == 0)
        {
            doorScript.Unlock();
        }
    }
}
