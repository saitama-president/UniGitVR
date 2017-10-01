using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace PropCreator
{

    [CustomEditor(typeof(PropCreator.RoomCreator))]
    public class RoomCreatorEdit : Editor
    {

        void OnSceneGUI()
        {
            //SceneビューのCamera取得
            /* 
               Debug.DrawLine(
               pos - camera.transform.right * size, pos + camera.transform.right * size, Color.yellow);
               Debug.DrawLine(pos - camera.transform.up * size,    pos  + camera.transform.up * size, Color.yellow);
             */
            //Sceneビュー更新
            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            if (GUILayout.Button("Generate"))
            {

                Debug.Log("押した!");
            }
        }



        //Cameraからフォーカスが外れたときに実行
        void OnDisable()
        {
            //Sceneビュー更新
            EditorUtility.SetDirty(target);
        }

        void OnEnable()
        {

        }
    }

}