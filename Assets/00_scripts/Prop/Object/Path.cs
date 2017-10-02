using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prop
{
    [RequireComponent (typeof (Rigidbody))]
    public class Path : MonoBehaviour
    {

        // Use this for initialization
        public List<Vector3> points;
        public Field From;
        public Field To;
        public void OnDrawGizmos()
        {

            //全体を表示
            Gizmos.color = new Color(1, 0, 0, 0.2F);
        }
    }

}
