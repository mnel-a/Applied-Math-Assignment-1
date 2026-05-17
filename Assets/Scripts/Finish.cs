using UnityEngine;

public class Finish : MonoBehaviour
{
    private PlayerMovement player;
    public float winDistance = 1f;
    private bool hasWon = false;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (player == null || hasWon)
            return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= winDistance)
        {
            hasWon = true;
            player.WinGame();
        }
    }

}
