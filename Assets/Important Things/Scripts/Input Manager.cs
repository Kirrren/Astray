using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode interact = KeyCode.E;
    public KeyCode dash = KeyCode.LeftShift;

    public Quaternion GetMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
        return Quaternion.Euler(-mouseY, mouseX, 0f);
    }

    public Vector3 GetMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        return new Vector3(moveX, 0, moveZ);
    }  
}
