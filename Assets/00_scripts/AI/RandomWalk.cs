using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour {

    public CharacterController c;

	// Use this for initialization
	IEnumerator Start () {


        while (true)
        {

            this.GetComponent<Rigidbody>().AddForce(
                 Quaternion.Euler(0, 90 * Random.Range(0, 4),0)*this.transform.forward
                ,ForceMode.VelocityChange
                );
                


            yield return new WaitForSeconds(1f);

            

        }



        yield break;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
