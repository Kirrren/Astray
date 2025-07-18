using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float XLookSensitivity;
    [SerializeField] float YLookSensitivity;
    
    Transform targetTransform;
    InputManager inputs;

    float targetX;
    float targetY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inputs = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        targetTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Quaternion lookDirection = inputs.GetMouseInput();
        //Debug.Log(lookDirection);
        RotateCam(lookDirection);
    }

    void RotateCam(Quaternion targetRotation)
    {
        targetY += targetRotation.eulerAngles.y * XLookSensitivity;
        //TODO: fix the x looking to prevent the camera from increasing straight to 90 (just try fixing it)
        targetX += 0f; //targetRotation.eulerAngles.x * YLookSensitivity;
        targetX = Mathf.Clamp(targetX, -90f, 90f);
        transform.rotation = Quaternion.Euler(targetX, targetY, 0f);
    }
}
