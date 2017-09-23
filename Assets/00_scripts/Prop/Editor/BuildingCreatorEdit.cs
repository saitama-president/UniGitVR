using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildingCreatorEdit : Editor {

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

    //Cameraからフォーカスが外れたときに実行
    void OnDisable()
    {
        //Sceneビュー更新
        EditorUtility.SetDirty(target);
    }
}
