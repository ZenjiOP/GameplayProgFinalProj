using UnityEngine;

public class showGizmo : MonoBehaviour {
    public float radius = 5.0f;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green; // Set color of the gizmo
        Gizmos.DrawWireSphere(transform.position, radius); // Draw wire sphere at the object's position
    }
}
