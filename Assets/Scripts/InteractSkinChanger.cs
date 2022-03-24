using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSkinChanger : MonoBehaviour
{
    public bool skinRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;


    void Update()
    {
        if (skinRange == true)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    public void SkinRange()
    {
        skinRange = true;
    }
    public void NotSkinRange()
    {
        skinRange = false;
    }
}
