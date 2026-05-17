using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public float hitDistance = 0.5f;
    private Vector2 moveDirection;
    private float moveSpeed;
    private Transform player;
    private PlayerMovement playerMovement;
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
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * moveSpeed * Time.deltaTime);

        if (player == null || playerMovement == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= hitDistance)
        {
            playerMovement.LoseGame();
            Destroy(gameObject);
            RestartGame();
        }
    }

      void RestartGame() 
    { 
        Time.timeScale = 1f; 
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ); 
    }
}
