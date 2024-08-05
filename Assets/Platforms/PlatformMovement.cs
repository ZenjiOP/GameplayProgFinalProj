using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public List<GameObject>Waypoints = new List<GameObject>();
    public float speed = 2.5f;

    List<Transform> WaypointTransforms = new List<Transform>();
    int currentWaypoint = 0;

    private void Start() {
        if (Waypoints.Count > 0) {
            foreach (GameObject waypoint in Waypoints) {
                WaypointTransforms.Add(waypoint.transform);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (WaypointTransforms.Count > 0) {
            Vector3 direction = WaypointTransforms[currentWaypoint].position - transform.position;
            
            direction.Normalize();
            
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, WaypointTransforms[currentWaypoint].position) < 0.1f) {
                currentWaypoint = (currentWaypoint + 1) % WaypointTransforms.Count;               
            }
        }
    }
}
