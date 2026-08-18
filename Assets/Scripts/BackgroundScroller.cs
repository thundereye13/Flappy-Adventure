using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float changeTime = 20f;

    public Transform background1;
    public Transform background2;

    public Sprite[] backgrounds;

    private float width;
    private float timer = 0f;
    private int currentBackground = 0;

    void Start()
    {
        width = background1.GetComponent<SpriteRenderer>().bounds.size.x;

        background1.position = new Vector3(
            0,
            background1.position.y,
            background1.position.z
        );

        background2.position = new Vector3(
            width,
            background2.position.y,
            background2.position.z
        );

        SetBackground();
    }

    void Update()
    {
        background1.position += Vector3.left * moveSpeed * Time.deltaTime;
        background2.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (background1.position.x <= -width)
        {
            background1.position += Vector3.right * width * 2;
        }

        if (background2.position.x <= -width)
        {
            background2.position += Vector3.right * width * 2;
        }

        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            timer = 0f;

            currentBackground++;

            if (currentBackground >= backgrounds.Length)
            {
                currentBackground = 0;
            }

            moveSpeed += 0.5f;

            SetBackground();
        }
    }

    void SetBackground()
    {
        background1.GetComponent<SpriteRenderer>().sprite = backgrounds[currentBackground];
        background2.GetComponent<SpriteRenderer>().sprite = backgrounds[currentBackground];
    }
}