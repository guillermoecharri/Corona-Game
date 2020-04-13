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
        //establish starting position for spawning platforms
        Vector3 startingPos = gameObject.transform.position;
        startingPos.y += platformBufferSize * spacingMultiplier;

        //spawn the starting set of platforms
        for (int i = 0; i < platformBufferSize; i++)
        {
            Vector3 pos = new Vector3(0, startingPos.y - i * spacingMultiplier, 0);
            if(i < platformBufferSize - 1)
            {
                Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
            }
            else
            {
                lastPlat = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
                Debug.Log("In Start() of PlatSpawner, lastPlat spawned at y pos: " + pos.y);
            }
        }
    }

    public void SpawnPlatform()
    {
        Vector3 newPlatPos = new Vector3(lastPlat.transform.position.x, lastPlat.transform.position.y - spacingMultiplier, lastPlat.transform.position.z);
        lastPlat = Instantiate(platforms[Random.Range(0, platforms.Length)], newPlatPos, Quaternion.identity) as GameObject;
        Debug.Log("spawning new play at y-position: " + newPlatPos);
    }

    public float GetDeleteThreshold()
    {
        return deleteThreshold;
    }
}
