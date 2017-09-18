using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorShot : MonoBehaviour {


    public float LastTime = 5.0f;

    public Transform root;
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
                this.body.position += (diff / 2) * Time.deltaTime;
            }
        }

    }

    public void Destroy()
    {
        //bodyを落とす
        this.anc.Release(this);
        GameObject.DestroyImmediate(this.gameObject);

    }

    //ぶつかった個所にjointを設定
    public void OnCollisionEnter(Collision collision)
    {
        this.anc.Join(this);
        Rigidbody r = this.GetComponent<Rigidbody>();
        r.isKinematic = true;

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
