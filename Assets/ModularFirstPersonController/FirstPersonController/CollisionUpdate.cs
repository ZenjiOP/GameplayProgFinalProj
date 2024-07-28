using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionUpdate : MonoBehaviour {

    public OrbManager orbManager;
    private List<SphereCollider> orbColliders = new List<SphereCollider>();

    public bool insideBox = false;
    public bool insideOrb = false;

    int playerLayer;
    int noPlatformsLayer;
    Collider thisCollider;

    LayerMask layerMask;


    public void Start() {
        playerLayer = LayerMask.NameToLayer("Player");
        noPlatformsLayer = LayerMask.NameToLayer("PlayerNoPlatforms");
        layerMask = LayerMask.NameToLayer("Platforms");

        thisCollider = GetComponent<Collider>();
        foreach (GameObject orb in orbManager.redOrbs) { 
            SphereCollider collider = orb.GetComponent<SphereCollider>();
            if (collider != null) {
                orbColliders.Add(collider);
            }
            else {
                Debug.LogWarning($"GameObject {orb.name} does not have a SphereCollider.");
            }
        }
        foreach (GameObject orb in orbManager.blueOrbs) {
            SphereCollider collider = orb.GetComponent<SphereCollider>();
            if (collider != null) {
                orbColliders.Add(collider);
            }
            else {
                Debug.LogWarning($"GameObject {orb.name} does not have a SphereCollider.");
            }
        }
    }

    public void Update() {
        CheckOverlaps();
        SetCollision();
    }

    private void CheckOverlaps() {
        Collider[] hitColliders = Physics.OverlapBox(thisCollider.bounds.center, thisCollider.bounds.extents, thisCollider.transform.rotation);

        insideBox = false;
        insideOrb = false;

        foreach (var hitCollider in hitColliders) {
            if (hitCollider != thisCollider && hitCollider.CompareTag("PlatformTrigger")) {
                insideBox = true; 
            }
            if (hitCollider != thisCollider && hitCollider.CompareTag("OrbRadius")) {
                insideOrb = true;
            }
        }
    }

    private void SetCollision() {
        if (insideBox && !insideOrb) {
            foreach (var collider in orbColliders) {
                collider.isTrigger = false;
            }
            // set layer to noplatforms
            gameObject.layer = noPlatformsLayer;
        }
        if (!insideBox && insideOrb) {
            foreach (var collider in orbColliders) {
                collider.isTrigger = true;
            }

            gameObject.layer = playerLayer;
        }
        if (!insideBox && !insideOrb) {
            // reset orbs to trigger
            foreach (var collider in orbColliders) {
                collider.isTrigger = true;
            }
            // set layer to noplatforms
            gameObject.layer = noPlatformsLayer;
        }
    }
}
