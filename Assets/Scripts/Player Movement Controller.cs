using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Components")]
    public Transform playerTransform;
    public Rigidbody playerRB;
    public InputManager inputs;
    public Animator playerAnim;

    [Header("Camera Components")]
    public Transform cameraTransform;

    public float playerSpd;

    public Transform playerOrientation;

    [Header("Physics")]
    public bool playerOnGround;
    public bool playerMoving;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<InputManager>();
        playerTransform = GetComponent<Transform>();
        playerAnim = GetComponent<Animator>();

        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        CheckPlayerStatus();
        Vector3 moveDirection = inputs.GetMovementInput();
        SetPlayerAnimation();
        SetPlayerOrientation(moveDirection);
        MovePlayer(moveDirection);
    }

    void SetPlayerOrientation(Vector3 moveDir)
    {
        Vector3 rotationValues = playerTransform.position - new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
        Vector3 moveOrientation = new Vector3(playerRB.linearVelocity.normalized.x, 0, playerRB.linearVelocity.normalized.z);
        playerOrientation.forward = rotationValues.normalized;
        playerTransform.forward = moveOrientation.magnitude > 0 ? moveOrientation : playerTransform.forward;   
    }

    void SetPlayerAnimation()
    {
        if (playerMoving)
        {
            playerAnim.Play("Walking");
        }
        else
        {
            playerAnim.Play("Standing");
        }
    }

    public void MovePlayer(Vector3 moveDir)
    {
        Vector3 moveForce = (moveDir.z * playerOrientation.forward + moveDir.x * playerOrientation.right).normalized * playerSpd;
        playerRB.AddForce(moveForce, ForceMode.Force);
    }

    public void CheckPlayerStatus()
    {
        playerMoving = playerRB.linearVelocity.magnitude > 3f;
    }
}
