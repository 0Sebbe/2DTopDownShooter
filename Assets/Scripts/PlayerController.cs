using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3f;
    Rigidbody2D rb;

    public Animator animator;

    private bool facingRight = true;

    Vector2 movement;
    Vector2 mousePos;

    public int speedTimer;


    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if(movement.x < 0 && facingRight)
        {
            Flip();
        }
        else if (movement.x > 0 && !facingRight)
        {
            Flip();
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Speedx", Mathf.Abs(movement.x));
        animator.SetFloat("Speedy", Mathf.Abs(movement.y));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void IncreaseSpeed(float increase)
    {
        if(movementSpeed < 4.5f)
        {
            speedTimer = speedTimer;
            movementSpeed *= increase;
            StartCoroutine(Timer());
        }

    }
    private IEnumerator Timer()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(speedTimer);
            movementSpeed /= 1.5f;
        }
    }

}
