using System;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

public class UpdateShaderProperties : MonoBehaviour {
    public GameObject orbManager;
    public GameObject[] orbArray = new GameObject[6]; // Assign the sphere object in the Inspector
    public Vector4[] orbV4 = new Vector4[6];

    private Renderer rend;
    private Material material;

    private void Start() {
        for (int i = 0; i < 6; i++) {
            orbArray[i] = orbManager.GetComponent<OrbManager>().orbs[i];
        }
        rend = GetComponent<Renderer>();
        material = rend.material;
    }

    void Update() {
        for (int i = 0; i < orbArray.Length; i++) { 
            if (orbArray[i] != null) {
                orbV4[i] = orbArray[i].transform.position;
                orbV4[i].w = orbArray[i].GetComponent<SphereCollider>().radius;
                if (material != null) {
                    material.SetVectorArray("_SphereCenters", orbV4);
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
