using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public GameObject redOrb;
    public GameObject blueOrb;
    public List<GameObject> redOrbs = new List<GameObject>();
    public List<GameObject> blueOrbs = new List<GameObject>();
    public int redSpawnedOrbRadiusIndex = 0;
    public int blueSpawnedOrbRadiusIndex = 0;

    public GameObject redThrownOrb;
    public List<GameObject> redThrownOrbs = new List<GameObject>();
    public GameObject blueThrownOrb;
    public List<GameObject> blueThrownOrbs = new List<GameObject>();

    public int redThrownOrbIndex = 0;
    public int blueThrownOrbIndex = 0;

    public TMP_Text ui_text;

    private void Update() {
        if (redThrownOrbIndex == 3)
            ui_text.text = "Press R to Recall Orbs";
        else
            ui_text.text = "";
    }

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 3; i++) {
            redThrownOrbs.Add(Instantiate(redThrownOrb, transform.position, Quaternion.identity));
            redThrownOrbs[i].GetComponent<ThrownOrbBahvior>().orbManager = this;
            blueThrownOrbs.Add(Instantiate(blueThrownOrb, transform.position, Quaternion.identity));
            blueThrownOrbs[i].GetComponent<ThrownOrbBahvior>().orbManager = this;
        }
        for (int i = 0; i < 3; i++) {
            redOrbs.Add(Instantiate(redOrb, transform.position, Quaternion.identity));
            blueOrbs.Add(Instantiate(blueOrb, transform.position, Quaternion.identity));
        }
    }

    public void ResetOrbs() {
        foreach (GameObject orb in redOrbs) {
            orb.transform.position = this.transform.position;
        }
        foreach (GameObject orb in blueOrbs) {
            orb.transform.position = this.transform.position;
        }
        redThrownOrbIndex = 0;
        blueThrownOrbIndex = 0;
    }
}
