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
        targetX += targetRotation.eulerAngles.x * YLookSensitivity;
        Debug.Log(targetX);
        targetX = Mathf.Clamp(targetX, -90f, 90f);
        transform.rotation = Quaternion.Euler(targetX, targetY, 0f);
    }
}
