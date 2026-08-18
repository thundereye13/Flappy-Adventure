using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnTime = 2f;

    private bool gameStarted = false;

    public void StartSpawning()
    {
        if (gameStarted)
            return;

        gameStarted = true;

        InvokeRepeating(nameof(SpawnPipe), 0f, spawnTime);
    }

    public void StopSpawning()
    {
        gameStarted = false;

        CancelInvoke(nameof(SpawnPipe));
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(-1.5f, 1.5f);

        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            randomY,
            transform.position.z
        );

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}