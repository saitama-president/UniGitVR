using System.Collections;
using UnityEngine;

public class TerrainEdit : MonoBehaviour
{
    public Terrain terrain;
    public TerrainCollider terrainCollider;

    public float size=1000;
    public float precision=0.5f;


    void Start ()
    {
        int w=(int)(size / precision);
        int h=(int)(size / precision);
        Debug.Log(w);
        float[,] heightMap = new float[
            w,
            h
            ];
        for(int x = 0 ; x < w ; x++){
            for(int y = 0 ; y < h ; y++){
                heightMap[x,y] = Mathf.Sin(x / 6.0F) / 2 + 0.5F;

            }
        }

        TerrainData data = new TerrainData();
        data.size = new Vector3(size,200,size);

        data.heightmapResolution = 2000 ;
        data.SetHeights(0, 0, heightMap);
        terrain.terrainData = data;
        
        terrainCollider.terrainData = data;
    }

    void Update(){
    }
}
