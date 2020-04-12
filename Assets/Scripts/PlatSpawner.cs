using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatSpawner : MonoBehaviour
{
    private static int platformBufferSize = 30; //all the platform layers loaded at once
    [SerializeField] float spacingMultiplier = 2;
    [SerializeField] GameObject[] platforms;
    GameObject lastPlat;
    [SerializeField] float deleteThreshold = 40;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 lastPos = new Vector3(0,0,0);
        for (int i = 0; i < platformBufferSize-1; i++)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += (i + 1) * spacingMultiplier;
            Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
            lastPos = new Vector3(0, pos.y + ((i + 1) * spacingMultiplier), 0);
        }
        lastPlat = Instantiate(platforms[Random.Range(0, platforms.Length)], lastPos, Quaternion.identity);
    }

    public void SpawnPlatform()
    {
        Vector3 newPlatPos = new Vector3(lastPlat.transform.position.x, lastPlat.transform.position.y - spacingMultiplier, lastPlat.transform.position.z);
        lastPlat = Instantiate(platforms[Random.Range(0, platforms.Length)], newPlatPos, Quaternion.identity);
        Debug.Log("spawn");
    }

    public float GetDeleteThreshold()
    {
        return deleteThreshold;
    }
}
