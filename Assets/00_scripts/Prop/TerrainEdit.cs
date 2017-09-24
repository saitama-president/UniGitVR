using System.Collections;
using UnityEngine;

public class TerrainEdit : MonoBehaviour
{
    public Terrain terrain;
    public TerrainCollider terrainCollider;

    public float size=1000;
    public float precision=0.5f;

    public Bounds bound;

    public int HeightMapResolution = 1;

    void Start ()
    {
        int w=(int)(size / precision);
        int h=(int)(size / precision);
        int res=(int)(size / precision);
        Debug.Log(w);
        float[,] heightMap = new float[
            w,
            h
            ];
        for(int x = 0 ; x < w ; x++){
            for(int y = 0 ; y < h ; y++){
                heightMap[x,y] = Mathf.Sin(x)*30f;

            }
        }

        TerrainData data = terrain.terrainData;
        //data.size = new Vector3(100, 100, 100);
        //data.size = new Vector3(size,200,size);
        
        
        //data.heightmapResolution =10;
        data.SetHeights(0, 0, heightMap);
       
        
    }

    void Update(){
    }
}
