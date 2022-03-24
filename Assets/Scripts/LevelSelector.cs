using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] lvlButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 5);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if(i + 5 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("House");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(5);
    }

    public void Level1()
    {
        SceneManager.LoadScene(6);
    }

    public void Level2()
    {
        SceneManager.LoadScene(7);
    }

    public void Level3()
    {
        SceneManager.LoadScene(8);
    }

    public void Level4()
    {
        SceneManager.LoadScene(9);
    }

    public void Level5()
    {
        SceneManager.LoadScene(10);
    }
}
