using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 5f;
    private float x;
    private float y;
    private Vector2 input;
    private bool moving;
    public GameObject Lose;
    public GameObject Win;

    void Update()
    {
        GetInput();
        Move();
        Animate();
    }

    void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);

        input.Normalize();
    }

    void Move()
    {
        transform.position += (Vector3)input * moveSpeed * Time.deltaTime;
    }

    void Animate()
    {
        if (input.magnitude > 0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }

    public void LoseGame()
        {
        Lose.SetActive(true);

        Time.timeScale = 0f;
        }

    public void WinGame()
    {
        Win.SetActive(true);

        Time.timeScale = 0f;
    }
}