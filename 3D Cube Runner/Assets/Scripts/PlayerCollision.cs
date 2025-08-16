using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public playerMovement movement;
    public Vector3 playerSize = Vector3.one;
    public string obstacleTag = "obstacle";

    private GameObject[] obstacles;
    private bool hasCollided = false;

    void Start()
    {
        // Automatically find all GameObjects with the "obstacle" tag
        obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);
    }

    void Update()
    {
        if (hasCollided) return; // Skip if already collided

        AABB playerBox = new AABB(transform.position, playerSize);

        foreach (GameObject obj in obstacles)
        {
            Vector3 size = GetWorldSize(obj);
            AABB obstacleBox = new AABB(obj.transform.position, size);

            if (AABB.CheckCollision(playerBox, obstacleBox))
            {
                hasCollided = true; // Mark that collision happened

                Debug.Log("Player hit an obstacle! Movement disabled.");
                movement.enabled = false;

                GameManager gm = FindFirstObjectByType<GameManager>();
                if (gm != null)
                {
                    gm.EndGame();
                }
                else
                {
                    Debug.LogWarning("GameManager not found in scene.");
                }

                break; // No need to check other obstacles
            }
        }
    }

    // Helper: gets the world space size of an obstacle based on its renderer bounds
    Vector3 GetWorldSize(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size;
        }
        return Vector3.one; // fallback if no renderer
    }
}
