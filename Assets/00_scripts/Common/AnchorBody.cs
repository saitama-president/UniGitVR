using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBody : MonoBehaviour {

    public List<AnchorShot> joins = new List<AnchorShot>();

    public void Join(AnchorShot shot)
    {
        if (joins.Count == 0)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        joins.Add(shot);
        
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
