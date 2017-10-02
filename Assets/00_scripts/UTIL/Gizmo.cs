using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util{

    public class Gizmo : MonoBehaviour {

        public static void DrawLabel(Vector3 pos,string label){
            #if UNITY_EDITOR
                UnityEditor.Handles.Label(pos,label);
            #endif
        }

    }
}
