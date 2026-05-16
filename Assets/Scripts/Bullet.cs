using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 moveDirection;
    private float moveSpeed;
    public float lifeTime = 5f;
    public float hitDistance = 0.5f;
    private Transform player;

    public void SetDirection(Vector2 direction, float speed)
    {
        moveDirection = direction;
        moveSpeed = speed;
    }

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found!");
        }

        Destroy(gameObject, lifeTime);

    }

    void Update()
    {
        transform.position +=
            (Vector3)(moveDirection * moveSpeed * Time.deltaTime);

        if (player != null)
        {
            float distance =
                Vector2.Distance(transform.position, player.position);

            PlayerMovement playerMovement =
                FindAnyObjectByType<PlayerMovement>();

            if (distance <= hitDistance)
            {
                playerMovement.LoseGame();
                RestartGame();
            }
        }

    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    
}
