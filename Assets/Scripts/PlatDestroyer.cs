using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestroyer : MonoBehaviour
{
    GameObject platSpawner;
    private bool newPlatNeeded = false;
    private float deleteThreshold;

    void Start()
    {
        platSpawner = GameObject.FindGameObjectWithTag("Spawner");
        deleteThreshold = platSpawner.GetComponent<PlatSpawner>().GetDeleteThreshold();
    }

    public void DestroyInit(float deleteThreshold)
    {
        this.deleteThreshold = deleteThreshold;
    }

    private void Update() //once per year yeeeeeeeeeeee
    {
        float platformPos = gameObject.transform.position.y;
        float spawnerPos = platSpawner.transform.position.y;
        if (platformPos - spawnerPos > deleteThreshold)
        {
            Debug.Log("pls spawn");
            platSpawner.GetComponent<PlatSpawner>().SpawnPlatform();
            Destroy(this.gameObject);
            Debug.Log("pls spawn called");
        }
    }

   
}
