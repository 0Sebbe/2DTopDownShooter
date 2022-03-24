using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void House()
    {
        SceneManager.LoadScene("House");
    }
    public void SkinSelector()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Quit");
        Application.Quit();
    }
}
