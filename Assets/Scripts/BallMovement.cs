using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 3f; // Initial speed of the ball
    private float speed; // Current speed of the ball
    private Vector2 direction; // Direction of the ball
    private int hitCounter = 0; // Hit counter
    public ScoreManager scoreManager;
    public Transform player1StartPosition; // Transform of player 1's start position
    public Transform player2StartPosition; // Transform of player 2's start position
    private float maxSpeed = 5;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Set initial direction
        direction = new Vector2(1, 1).normalized;
        speed = initialSpeed;

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void RestartBall()
    {
        // Reset ball position to the center
        transform.position = Vector3.zero;

        // Reset hit counter
        hitCounter = 0;

        // Reset speed
        speed = initialSpeed;

        // Reset direction based on which player last scored
        if (scoreManager != null)
        {
            if (scoreManager.lastPlayerScored == 1)
            {
                direction = new Vector2(1, 1).normalized; // Ball moves towards player 2
            }
            else if (scoreManager.lastPlayerScored == 2)
            {
                direction = new Vector2(-1, 1).normalized; // Ball moves towards player 1
            }
        }
    }

    void Update()
    {
        // Move the ball
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the ball hits the top or bottom wall, reverse Y direction
        if (transform.position.y <= -4.5f || transform.position.y >= 4.5f)
        {
            direction = new Vector2(direction.x, -direction.y);
        }

        // Apply a speed limit if necessary
        speed = Mathf.Clamp(speed, 0f, maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            // Reverse X direction if the ball hits a paddle
            direction = new Vector2(-direction.x, direction.y);

            // Increase hit counter
            hitCounter++;

            // Increase speed every 5 hits
            if (hitCounter % 5 == 0)
            {
                speed += 1f; // Increase speed by 1
            }

            // Play the paddle hit sound from the attached AudioSource component
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
        else if (other.gameObject.CompareTag("Right Border"))
        {
            scoreManager.Player1CurrentScore(); // Increase player 1's score by 1
            RestartBall();
        }
        else if (other.gameObject.CompareTag("left Border"))
        {
            scoreManager.Player2CurrentScore(); // Increase player 2's score by 1
            RestartBall();
        }
    }
}



