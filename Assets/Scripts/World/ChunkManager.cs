using System.Collections.Generic;
using UnityEngine;

/* 
*  Each chunk is a half width tilemap that seamlessly lines up with all other chunks
*  As the chunks scroll left, new ones load in from the right
*/

public class ChunkManager : MonoBehaviour
{
    public Transform worldParent;
    public GameObject[] chunkPrefabs;
    private float chunkWidth = 10f;
    private List<GameObject> activeChunks = new List<GameObject>();
    private float spawnX = 0f;

    private int chunksToKeepInMem = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn 3 chunks to fill the inital screen + 1/2
        for (int i = 0; i < 3; i++)
        {
            SpawnChunk();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // convert local spawnX to world space for camera comparison
        if (worldParent.position.x + spawnX < Camera.main.orthographicSize * Camera.main.aspect + chunkWidth)
        {
            SpawnChunk();
            RemoveOldChunk();
        }

    }

    //create a new chunk
    void SpawnChunk()
    {
        GameObject chunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)], worldParent);
        chunk.transform.localPosition = new Vector3(spawnX, 0, 0);
        spawnX += chunkWidth;
        activeChunks.Add(chunk);
    }

    //remove old chunks 
    void RemoveOldChunk()
    {
        if (activeChunks.Count > chunksToKeepInMem)
        {
            GameObject oldChunk = activeChunks[0];
            activeChunks.RemoveAt(0);
            Destroy(oldChunk);
        }
    }
}