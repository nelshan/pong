using UnityEngine;

public class Players : MonoBehaviour
{
    public float speed = 5f; // Speed of the paddle

    public KeyCode upKey; // Up key for player 1 or player 2
    public KeyCode downKey; // Down key for player 1 or player 2

    void Update()
    {
        // Get input for player 1 or player 2
        float input = 0f;
        if (Input.GetKey(upKey))
        {
            input = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            input = -1f;
        }

        // Move the paddle
        transform.Translate(Vector2.up * input * speed * Time.deltaTime);
        
        // Clamp paddle position to stay within the game area
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}

