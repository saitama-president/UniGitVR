using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorRoll : MonoBehaviour {

    public Joint j;
	// Use this for initialization
	void Start () {
        j.autoConfigureConnectedAnchor = false;
	}
	
	// Update is called once per frame
	void Update () {
        j.connectedAnchor *= 1 - (0.33f*Time.deltaTime);
	}
}
