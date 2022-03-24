using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public int kills = 0;
    public Text killUI;
    public int waveKills = 15;

    public void Update()
    {
        ShowKills();
    }

    void ShowKills()
    {
        killUI.text = "Kills - " + kills.ToString();
    }
    public void AddKill()
    {
        kills++;
    }

}
