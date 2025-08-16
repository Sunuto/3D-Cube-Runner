using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered End Trigger!");
        gameManager.Completelevel();
    }
}
