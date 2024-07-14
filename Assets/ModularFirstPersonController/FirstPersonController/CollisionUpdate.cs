using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionUpdate : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter(Collider trigger) {
        if (trigger.CompareTag("OrbRadius")) { 
            if (box != null) {
                if (Vector3.Distance(box.transform.position, transform.position) <= trigger.GetComponent<SphereCollider>().radius) {
                    // Enable the box collider
                    box.GetComponent<BoxCollider>().enabled = true;
                    Debug.Log("Player is within the sphere collider's radius.");
                }
            }
        }
    }

    private void OnTriggerExit(Collider trigger) {
        if (trigger.CompareTag("OrbRadius")) {
            if (box != null) {
                box.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("Player is within the sphere collider's radius.");
            }
        }
    }
}
