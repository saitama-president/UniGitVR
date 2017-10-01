using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PropCreator
{



    [CustomEditor(typeof(PropCreator.WorldCreator))]
    public class WorldCreatorEdit : Editor
    {

        void OnSceneGUI()
        {
            WorldCreator o = (WorldCreator)(this.target);

            //SceneビューのCamera取得
            /* 
               Debug.DrawLine(
               pos - camera.transform.right * size, pos + camera.transform.right * size, Color.yellow);
               Debug.DrawLine(pos - camera.transform.up * size,    pos  + camera.transform.up * size, Color.yellow);
             */
            //Sceneビュー更新
            EditorUtility.SetDirty(target);
        }


        private string num2A(int i)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[i].ToString();
        }

        public override void OnInspectorGUI()
        {

            
            WorldCreator o = (WorldCreator)(this.target);

            UnityEditor.Handles.Label(o.transform.position, name);

            base.OnInspectorGUI();
            if (GUILayout.Button("Reset"))
            {
                foreach (Transform n in o.transform)
                {
                    GameObject.DestroyImmediate(n.gameObject);
                }

                for (int x = 0; x < o.SplitSize.x; x++)
                {
                    for (int y = 0; y < o.SplitSize.y; y++)
                    {
                        
                        Vector3 blockSize = new Vector3(
                            o.WorldBound.x/o.SplitSize.x,
                            0,
                            o.WorldBound.z/o.SplitSize.y

                            );
                        Debug.Log(blockSize);
                        GameObject block = new GameObject();
                        block.name = string.Format("{0}:{1}",
                            this.num2A(x),
                            y);
                        Terrain t=block.AddComponent<Terrain>() as Terrain;
                        TerrainData Data = new TerrainData();
                        TerrainCollider c = new TerrainCollider();

                        Data.size = blockSize;
                        t.terrainData = Data;

                        block.transform.position=
                            o.transform.position
                            +new Vector3(
                                blockSize.x*x,
                                0,
                                blockSize.z*y)
                                ;
                        
                        
                        block.transform.SetParent(o.transform);
                    }
                }


                
                //Data.SetDetailResolution(1,1);

                



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