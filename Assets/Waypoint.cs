using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 0.5f);
        for (int i = 0; i < waypoints.Count - 1; i++) {
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }
}
