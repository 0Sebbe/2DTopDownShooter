using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactebles : MonoBehaviour
{
    public bool mapRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;


    void Update()
    {
        if (mapRange == true)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    public void MapRange()
    {
        mapRange = true;
    }
    public void NotMapRange()
    {
        mapRange = false;
    }
}
