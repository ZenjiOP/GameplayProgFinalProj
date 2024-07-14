using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public GameObject orb;
    public List<GameObject> orbs = new List<GameObject>();
    public int spawnedOrbRadiusIndex = 0;

    public GameObject thrownOrb;
    public List<GameObject> thrownOrbs = new List<GameObject>();
    public int thrownOrbIndex = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 6; i++) {
            thrownOrbs.Add(Instantiate(thrownOrb, transform.position, Quaternion.identity));
            thrownOrbs[i].GetComponent<ThrownOrbBahvior>().orbManager = this;
        }
        for (int i = 0; i < 6; i++) {
            orbs.Add(Instantiate(orb, transform.position, Quaternion.identity));
        }
    }
}
