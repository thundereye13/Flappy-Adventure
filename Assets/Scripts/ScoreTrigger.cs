using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scoreGiven = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scoreGiven)
            return;

        if (other.CompareTag("Player"))
        {
            Bird bird = other.GetComponent<Bird>();

            if (bird != null && bird.IsGameOver)
                return;

            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null && gameManager.IsGameOver)
                return;

            scoreGiven = true;

            if (gameManager != null)
            {
                gameManager.AddScore();
            }
        }
    }
}