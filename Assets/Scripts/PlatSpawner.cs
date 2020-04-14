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
    [SerializeField] GameObject playerSpawner; //remove later
    [SerializeField] GameObject player;
    bool spawnPlatFound = false;

    // Start is called before the first frame update
    private void Awake()
    {
        //playerSpawner.SetActive(true); //delete later
    }

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
                if((player.transform.position.y - pos.y) >= (spacingMultiplier/2) && !spawnPlatFound)
                {
                    spawnPlatFound = true;
                    GameObject spawnPlat = Instantiate(platforms[Random.Range(1, 5)], pos, Quaternion.identity);
                    player.transform.position = new Vector3(spawnPlat.transform.position.x, spawnPlat.transform.position.y + 0.5f, spawnPlat.transform.position.z);
                }
                else
                {
                    Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity); // original
                }
                
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
