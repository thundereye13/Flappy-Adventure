using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject startPanel;

    public bool IsGameOver { get; private set; } = false;

    public Bird bird;
    public PipeSpawner pipeSpawner;

    public int highScore = 0;
    public TextMeshProUGUI highScoreText;

    // Sounds
    public AudioClip scoreSound;
    public AudioClip gameOverSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (highScoreText != null)
        {
            highScoreText.text = "Best: " + highScore;
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        score = 0;

        if (scoreText != null)
        {
            scoreText.text = "0";
        }

        IsGameOver = false;

        bird.StartBird();
        pipeSpawner.StartSpawning();
    }

    public void AddScore()
    {
        if (IsGameOver)
            return;

        score++;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        // Score sound
        if (scoreSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (highScoreText != null)
            {
                highScoreText.text = "Best: " + highScore;
            }
        }
    }

    public void SetGameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        pipeSpawner.StopSpawning();

        // Game Over sound
        if (gameOverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}