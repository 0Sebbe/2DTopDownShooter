using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCol;
    public void Unlock()
    {
        animator.SetBool("Unlocked", true);
        boxCol.enabled = false;
    }
}
