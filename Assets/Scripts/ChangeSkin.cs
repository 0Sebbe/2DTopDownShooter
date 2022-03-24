using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController Player1;
    public AnimatorOverrideController Player2;
    public AnimatorOverrideController Player3;
    public AnimatorOverrideController Player4;
    public AnimatorOverrideController Player5;

    public int skinNumber = 0;

    Skinmanager skinmanager;

    public void Update()
    {
        skinmanager = GameObject.Find("Skinmanager").GetComponent<Skinmanager>();
        skinNumber = SkinStateController.skinNumber;

        if (skinNumber == 0)
        {
            GetComponent<Animator>().runtimeAnimatorController = Player1 as RuntimeAnimatorController;
        }
        if(skinNumber == 1)
        {
            GetComponent<Animator>().runtimeAnimatorController = Player2 as RuntimeAnimatorController;
        }
        if (skinNumber == 2)
        {
            GetComponent<Animator>().runtimeAnimatorController = Player3 as RuntimeAnimatorController;
        }
        if (skinNumber == 3)
        {
            GetComponent<Animator>().runtimeAnimatorController = Player4 as RuntimeAnimatorController;
        }
        if (skinNumber == 4)
        {
            GetComponent<Animator>().runtimeAnimatorController = Player5 as RuntimeAnimatorController;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("House");
    }
    public void Player5Skin()
    {
        skinmanager.GetComponent<Skinmanager>().Player5();
    }
    public void Player4Skin()
    {
        skinmanager.GetComponent<Skinmanager>().Player4();
    }
    public void Player3Skin()
    {
        skinmanager.GetComponent<Skinmanager>().Player3();
    }
    public void Player2Skin()
    {
        skinmanager.GetComponent<Skinmanager>().Player2();
    }
    public void Player1Skin()
    {
        skinmanager.GetComponent<Skinmanager>().Player1();
    }
}
