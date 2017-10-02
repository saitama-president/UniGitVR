using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**

FieldCreator→BuildingCreator→FloorCreator
の順

*/
namespace PropCreator
{
    public class BuildingCreator : MonoBehaviour
    {

        // Use this for initialization

        public Vector3 FloorSize = new Vector3(10, 3, 10);


        //壁
        public float MarginTop = 0.2f;
        public float MarginBottom = 0.3f;
        public float MarginWall = 0.2f;


        //各必要なオブジェクトの数
        public int Stairs = 2;//階段の数
        public int Floors = 5;//階の数

        public Object FloorPrefab;
        public Object WallPrefab;
        public Object TilePrefab;


        void Start()
        {

        }

        public void OnDrawGizmos()
        {

            //全体を表示
            Gizmos.color = new Color(1, 0, 0, 0.2F);
            Gizmos.DrawCube(
                this.transform.position
                + Vector3.up * FloorSize.y * Floors / 2,//階数分だけ底上げ
                new Vector3(FloorSize.x, FloorSize.y * Floors, FloorSize.z) * 1.01f
                );

            //各フロアを表示
            Gizmos.color = new Color(1, 1, 0, 0.2F);
            for (int i = 0; i < Floors; i++)
            {
                Gizmos.DrawCube(this.transform.position
                + Vector3.up * FloorSize.y / 2
                + Vector3.up * FloorSize.y * i,
                FloorSize * 0.99f);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
