using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private PlayerMovement player;
    public float winDistance = 1f;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= winDistance)
        {
            player.WinGame();
            RestartGame();
        }
    }

    void RestartGame() 
    { 
        Time.timeScale = 1f; 
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ); 
    }
}
