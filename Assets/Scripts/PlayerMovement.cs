using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 5f;
    public GameObject winUI;
    private Vector2 input;
    private bool moving;
    public GameObject restartButton;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        GetInput();
        Move();
        Animate();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    void Move()
    {
        transform.position += (Vector3)(input * moveSpeed * Time.deltaTime);
    }

    void Animate()
    {
        moving = input.magnitude > 0.1f;

        if (moving)
        {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
        }

        anim.SetBool("Moving", moving);
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }
}