using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    PlayerMovement player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }
   void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        if (distance < 1f)
        {
            player.WinGame();
            RestartGame();
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
