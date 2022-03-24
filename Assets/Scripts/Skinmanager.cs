using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skinmanager : MonoBehaviour
{

    public void Player1()
    {
        SkinStateController.skinNumber = 0;
    }
    public void Player2()
    {
        SkinStateController.skinNumber = 1;
    }

    public void Player3()
    {
        SkinStateController.skinNumber = 2;
    }

    public void Player4()
    {
        SkinStateController.skinNumber = 3;
    }

    public void Player5()
    {
        SkinStateController.skinNumber = 4;
    }
}
    