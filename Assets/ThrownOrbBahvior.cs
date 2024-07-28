using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownOrbBahvior : MonoBehaviour
{
    public OrbManager orbManager;

    Vector3 impactPoint;

    private void Awake() {
        int[] layersToExclude = { 6 };
        this.gameObject.GetComponent<SphereCollider>().excludeLayers = LayerMask.GetMask("Player");
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("OrbRadius")) {
            impactPoint = transform.position;

            orbManager.redOrbs[orbManager.redSpawnedOrbRadiusIndex].transform.position = impactPoint;
            orbManager.redSpawnedOrbRadiusIndex = (orbManager.redSpawnedOrbRadiusIndex + 1) % orbManager.redOrbs.Count;
            Debug.Log($"Spawning Orb Radius {orbManager.redSpawnedOrbRadiusIndex} at location: {transform.position}");
            transform.position = orbManager.transform.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
