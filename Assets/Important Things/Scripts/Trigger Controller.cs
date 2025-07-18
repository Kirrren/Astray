using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public bool triggerEntered;
    public GameObject collisionObject;

    [SerializeField] string tagToDetect = "null";

    void OnTriggerStay(Collider other)
    {
        if (tagToDetect == "null" || other.CompareTag(tagToDetect))
        {
            collisionObject = other.gameObject;
            triggerEntered = true;
        }
    }

    void OnTriggerExit()
    {
        triggerEntered = false;
    }
}