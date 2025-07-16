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

    public Transform playerOrientation;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<InputManager>();
        playerTransform = GetComponent<Transform>();

        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        setPlayerOrientation();
        Vector3 moveDirection = inputs.GetMovementInput();
        MovePlayer(moveDirection);
    }

    void setPlayerOrientation()
    {
        Vector3 rotationValues = playerTransform.position - new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
        playerOrientation.forward = rotationValues.normalized;
    }

    public void MovePlayer(Vector3 moveDir)
    {
        Vector3 moveForce = (moveDir.z * playerOrientation.forward + moveDir.x * playerOrientation.right).normalized * playerSpd;
        playerRB.AddForce(moveForce, ForceMode.Force);
    }
}
