using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour {

	// Use this for initialization
	public Bounds BuildingBounds;

	public Vector3 FloorSize;
	public int Floors=5;

	public float FloorHeight;
	public Object FloorPrefab;
	public Object WallPrefab;

	void Start () {
		
	}

    //発生範囲を表示
    public void OnDrawGizmos(){
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(
			this.transform.position,
			new Vector3(FloorSize.x,FloorSize.y*Floors,FloorSize.z)*1.1f
			);
		Gizmos.color = new Color(1, 1, 0, 0.5F);
		for(int i=0;i<Floors;i++){
			Gizmos.DrawCube(this.transform.position
			+new Vector3(0,FloorSize.y,0)*i,
			FloorSize);
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
