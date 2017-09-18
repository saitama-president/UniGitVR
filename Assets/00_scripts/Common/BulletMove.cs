using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float Speed = 1.0f;

    

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().AddForce(
            this.transform.forward * Speed, ForceMode.VelocityChange
            );
        GameObject.Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
