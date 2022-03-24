using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    Text scoretext;

    public void Start()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        scoretext = GetComponent<Text>();
        scoreValue = score;
    }
    void Update()
    {
        scoretext.text = "" + PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", scoreValue);
    }
}
