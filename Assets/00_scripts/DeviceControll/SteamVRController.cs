using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRController : MonoBehaviour {

    //飛ばすアンカー
    public Object Bullet;

    //public bool isReadyShoot = true;
    public AnchorShot anchor;

	void Start () {
		
	}

    void Update()
    {
        SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //指示ビームを出す？
//            Debug.Log("トリガーを浅く引いた");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Fire();
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Release();
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
//            Debug.Log("タッチパッドをクリックした");
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Y軸を回転させる
            Vector2 v=device.GetAxis();
            if (v.x < -0.25)
            {
                this.transform.parent.rotation *= Quaternion.Euler(0, -45 * Time.deltaTime, 0);
            } 
            else if(0.25 < v.x)
            {
                this.transform.parent.rotation *= Quaternion.Euler(0, 45 * Time.deltaTime, 0);
            }

        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドをクリックして離した");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドに触った");
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドを離した");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log("メニューボタンをクリックした");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("グリップボタンをクリックした");
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを浅く引いている");
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを深く引いている");
        }
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Debug.Log("タッチパッドに触っている");
        }
        
    }

    public void Fire()
    {
        if (this.anchor) return;
        //アンカを投げる
        this.anchor=GameObject.Instantiate(Bullet,this.transform.position,this.transform.rotation) as AnchorShot;

        this.anchor.body = this.transform.parent;
        this.anchor.anc = this.transform.parent.GetComponent<AnchorBody>();
    }
    
    //アンカを回収
    public void Release()
    {
        if (!this.anchor) return;
        anchor.Destroy();
    }
}
