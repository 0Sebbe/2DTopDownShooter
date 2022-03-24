using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinStall : MonoBehaviour
{
    public bool open = false;
    public float distance;
    private Transform player;
    InteractSkinChanger interactebles;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactebles = GameObject.Find("InteractSkinChanger").GetComponent<InteractSkinChanger>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < distance)
        {
            interactebles.GetComponent<InteractSkinChanger>().SkinRange();
        }
        else
        {
            interactebles.GetComponent<InteractSkinChanger>().NotSkinRange();
        }
    }
    public void SelectSkin()
    {
        if (!open)
        {
            open = true;
            SceneManager.LoadScene(2);
        }
    }
}
