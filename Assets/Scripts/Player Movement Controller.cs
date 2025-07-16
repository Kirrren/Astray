using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Components")]
    public Transform playerTransform;
    public Rigidbody playerRB;
    public InputManager inputs;

    public float playerSpd;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<InputManager>();  
        playerTransform = GetComponent<Transform>();
    }
}
