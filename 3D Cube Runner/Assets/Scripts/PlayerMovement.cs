using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardF = 200f;
    public float sidewayForce = 500f;

    private GameManager gameManager;

    void Start()
    {
        // Optional: make sure gravity is enabled
        // rb.useGravity = true;

        // Cache GameManager
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        // Stop movement if game ended or level is complete
        if (gameManager.GameHasEnded || gameManager.LevelCompleted) return;

        // Forward movement
        rb.AddForce(0, 0, ForwardF * Time.deltaTime);

        // Left / Right movement
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Fall detection
        if (rb.position.y < -1f)
        {
            FindFirstObjectByType<GameManager>().EndGame();
        }
    }
}
