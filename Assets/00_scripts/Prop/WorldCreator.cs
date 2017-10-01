using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PropCreator
{
    public class WorldCreator : MonoBehaviour
    {
        // Use this for initialization
        public Vector3 WorldBound = new Vector3(100, 3, 100);

        public Vector2 SplitSize = new Vector2(5,5);

        public Vector3 offset {
            get
            {
                return new Vector3(WorldBound.x / 2, 0, WorldBound.z / 2);

            }
        }

        public Terrain terrain{
            get {
                return GetComponent<Terrain>();
            }
        }


        private void Awake()
        {

        }


        void Start()
        {

        }

        public void OnDrawGizmos()
        {


            //床を表示
            Gizmos.color = new Color(1, 1f, 1, 0.5F);

            Gizmos.DrawCube(
            this.transform.position + offset,
                new Vector3(WorldBound.x,0.1f,WorldBound.z)
            );
            //全体表示
            Gizmos.color = new Color(0.1f, 0.1f, 0.1f, 0.2F);

            Gizmos.DrawCube(
                this.transform.position+ offset,
                WorldBound*1.01f
            );


            //地上部分
            Gizmos.color = new Color(0, 0.7f, 1, 0.2F);
            
            Gizmos.DrawCube(
            new Vector3(
                this.transform.position.x,
                this.transform.position.y+ (WorldBound.y /4),
                this.transform.position.z
            ) + offset

            ,
                new Vector3(WorldBound.x, WorldBound.y/2, WorldBound.z)
            );

            //地下部分

            Gizmos.color = new Color(0.5f, 0.2f, 0, 0.2F);
            
            Gizmos.DrawCube(
                        new Vector3(
                this.transform.position.x,
                this.transform.position.y - (WorldBound.y /4),
                this.transform.position.z
            ) + offset
            ,
                new Vector3(WorldBound.x, WorldBound.y/2, WorldBound.z)
            );

            //子画面
            foreach(Transform t in this.transform)
            {
#if UNITY_EDITOR
                UnityEditor.Handles.Label(t.position, t.gameObject.name);
#endif
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}


