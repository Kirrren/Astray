using UnityEngine;

public class cinematic_camera_script_for_bedroom : MonoBehaviour
{
    [SerializeField] float rotMult;
    [SerializeField] float FOVMult;
    void Update()
    {
        Transform currentTrans = GetComponent<Transform>();
        //currentTrans.rotation = Quaternion.Euler(90, 270f, Time.deltaTime * rotMult);
        GetComponent<Camera>().fieldOfView -= Time.deltaTime * FOVMult;
    }
}
