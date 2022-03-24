using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTable : MonoBehaviour
{
    public bool open = false;
    public float distance;
    private Transform player;
    Interactebles interactebles;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactebles = GameObject.Find("InteractController").GetComponent<Interactebles>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < distance)
        {
            interactebles.GetComponent<Interactebles>().MapRange();
        }
        else
        {
            interactebles.GetComponent<Interactebles>().NotMapRange();
        }
    }
    public void SelectLevel()
    {
        if (!open)
        {
            open = true;
            SceneManager.LoadScene(4);
        }
    }
}
