using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    public float rotationSpeed = 5f;

    public AudioClip flapSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    private bool isGameOver = false;
    private bool gameStarted = false;

    public bool IsGameOver => isGameOver;

    public GameObject gameOverText;
    public GameObject restartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.simulated = false;
    }

    void Update()
    {
        if (!gameStarted || isGameOver)
            return;

        if ((Keyboard.current != null &&
             Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (Touchscreen.current != null &&
             Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
        {
            rb.linearVelocity = Vector2.up * jumpForce;

            if (flapSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(flapSound);
            }
        }

        float angle = rb.linearVelocity.y * rotationSpeed;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void StartBird()
    {
        gameStarted = true;
        rb.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameStarted || isGameOver)
            return;

        isGameOver = true;

        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.SetGameOver();
        }

        rb.linearVelocity = Vector2.zero;

        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }
}