using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorShot : MonoBehaviour {


    public Transform body;
    public AnchorBody anc;

    public bool isReturnAnchor=false; 

	// Use this for initialization
	void Start () {
        //this.GetComponent<Joint>().
        StartCoroutine(waitAnchor(0.3f));
	}
    IEnumerator waitAnchor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(this.GetComponent<TrailRenderer>());

        isReturnAnchor = true;
        //5秒で消滅
        yield return new WaitForSeconds(5f);
        this.Destroy();
        yield break;
    }
	
	// Update is called once per frame
	void Update () {

        //長く伸びたら戻る
        if (isReturnAnchor)
        {
            Vector3 diff = this.transform.position - this.body.position;
            if (this.GetComponent<Rigidbody>().isKinematic)
            {
                //体を引っ張る
                //this.GetComponent<Joint>().connectedAnchor *= 1 - (0.5f * Time.deltaTime);
                this.body.position += diff * Time.deltaTime;
            }
        }

    }

    public void Destroy()
    {
        //bodyを落とす
        GameObject.DestroyImmediate(this.gameObject);
    }

    public void OnDestroy(){
        base.OnDestroy();
        this.anc.Release(this);
    }

    //ぶつかった個所にjointを設定
    public void OnCollisionEnter(Collision collision)
    {
        if(!isReturnAnchor)return;
        
        this.anc.Join(this);
        Rigidbody r = this.GetComponent<Rigidbody>();
        r.isKinematic = true;

        //根本も両方hingeである方がgood
        HingeJoint j=this.gameObject.AddComponent<HingeJoint>();
        j.connectedBody = body.GetComponent<Rigidbody>();
        j.autoConfigureConnectedAnchor = false;
        j.useSpring = true;
        JointSpring sp=new JointSpring();
        sp.damper = 0.2f;
        sp.spring = 0.2f;
        j.spring = sp;

    }
}
