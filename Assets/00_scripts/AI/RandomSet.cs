using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSet : MonoBehaviour {

    public List<Object> props;

    public int CreateCount = 30;
    public Bounds CreateBound;

	// Use this for initialization
	void Awake () {

        for (int i = 0;i < CreateCount;i++){
            Object prefab = props[Random.Range(0, props.Count - 1)];


            GameObject.Instantiate(prefab, 
                new Vector3(
                    Random.Range(CreateBound.min.x,CreateBound.max.x),
                    Random.Range(CreateBound.min.y, CreateBound.max.y),
                    Random.Range(CreateBound.min.z, CreateBound.max.z)


                    ), this.transform.rotation);

        }


        //終わったのでさようなら
        GameObject.Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
