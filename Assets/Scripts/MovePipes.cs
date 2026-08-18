using UnityEngine;

public class MovePipes : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null && gameManager.IsGameOver)
            return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
    }
}