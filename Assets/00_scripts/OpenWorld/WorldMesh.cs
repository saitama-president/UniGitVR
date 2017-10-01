
using UnityEngine;

namespace UNIGIT
{
    class Mesh
    {

        public static UnityEngine.Mesh MeshFromMesh(UnityEngine.Mesh mesh)
        {



            //サブメッシュの数だけループ

            for (int m = 0; m < mesh.subMeshCount; m++)
            {
                //ポリゴンのインデックスを取得する
                int[] triangles = mesh.GetTriangles(m);
                //ポリゴンなので３つずつインクリメントしてループ 
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    //２番目と３番目の頂点インデックスを入れ替えて三角形を反転する 
                    int index = triangles[i + 1];
                    triangles[i + 1] = triangles[i + 2];
                    triangles[i + 2] = index;
                }
                //ポリゴンのインデックスをメッシュに戻す 
                mesh.SetTriangles(triangles, m);
            }
            //法線を再計算する 
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}
