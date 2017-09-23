using System.Collections;
using UnityEngine;
public class WorldTerra : MonoBehaviour
{
    public Terrain terrain;
    public TerrainCollider terrainCollider;

    public float size=1000;
    public float precision=0.5f;


    void Start ()
    {
        float[,] heightMap = new float[
            (int)(size / precision),
            (int)(size / precision)
            ];
        for(int x = 0 ; x < 100 ; x++){
            for(int y = 0 ; y < 100 ; y++){
//                heightMap[x,y] = Mathf.Sin(w / 6.0F) / 2 + 0.5F;
            }
        }

        TerrainData data = new TerrainData();
        data.size = new Vector3(size,200,size);

        data.heightmapResolution = (int)( size / precision) ;
        data.SetHeights(0, 0, heightMap);

        terrain.terrainData = data;
        terrainCollider.terrainData = data;
    }

    void Update(){
    }
}
