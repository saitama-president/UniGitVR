using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PropCreator
{
    public class FieldCreator
        : MonoBehaviour
    {

        // Use this for initialization

        public Vector2 FieldSize = new Vector2(50,50);
        public int Buildings = 5;

        public Object FloorPrefab;


        void Start()
        {

        }

        public void OnDrawGizmos()
        {

            //全体を表示
            Gizmos.color = new Color(1, 0, 0.5f, 0.2F);
            Gizmos.DrawCube(
                this.transform.position,
                new Vector3(FieldSize.x,0.1f,FieldSize.y)
                );
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}