using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBody : MonoBehaviour {

    public List<AnchorShot> joins = new List<AnchorShot>();
    /*
        くっつけるjoint
    */
    public Joint LJoint;
    public Joint RJoint;
    
    public Vector3 inertia=Vector3.Zero;

    public void Join(AnchorShot shot)
    {
        if (joins.Count == 0)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        joins.Add(shot);
    }

    public void Update(){
//        Vector3 ancPos=Vector3.Zero
        
        
        this.transform.position+=inertia*Time.deltaTime;


        //慣性を殺す方法？無いよ！

    }

    public void Release(AnchorShot shot)
    {
        joins.Remove(shot);
        if (joins.Count == 0)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
