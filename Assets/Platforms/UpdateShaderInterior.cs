using System;
using UnityEngine;

public class UpdateShaderInterior : MonoBehaviour {
    public GameObject ExteriorObj;
    public UpdateShaderProperties ExteriorShaderScript;

    Renderer rend;

    private void Start() {
        ExteriorShaderScript = ExteriorObj.GetComponent<UpdateShaderProperties>();
        rend = GetComponent<Renderer>();
    }

    void Update() {
        if (rend != null) {
            Material material = rend.material;
            if (material != null) {
                material.SetVectorArray("_SphereCenters", ExteriorShaderScript.orbV4);
            }
        }
    }
}
