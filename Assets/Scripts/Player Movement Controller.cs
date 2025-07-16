using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Components")]
    public Transform playerTransform;
    public Rigidbody playerRB;
    public InputManager inputs;

    [Header("Camera Components")]
    public Transform cameraTransform;

    public float playerSpd;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<InputManager>();
        playerTransform = GetComponent<Transform>();

        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        Vector3 moveDirection = inputs.GetMovementInput();
        MovePlayer(moveDirection);
    }

    public void MovePlayer(Vector3 moveDir)
    {
        Vector3 moveForce = (moveDir.x * cameraTransform.right + moveDir.z * cameraTransform.forward).normalized * playerSpd;
        playerRB.AddForce(moveForce, ForceMode.Force);
    }
}
