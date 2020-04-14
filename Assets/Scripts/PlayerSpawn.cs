using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject platform;
    bool foundPlat = false;
    bool movePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foundPlat && !movePlayer)
        {
            movePlayer = true;
            Vector3 platPos = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z);
            player.transform.position = platPos;
        }
        else if(foundPlat && movePlayer)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("collided");
        if (other.CompareTag("Platform") && !foundPlat)
        {
            foundPlat = true;
            platform = other.gameObject;
        }
        else if (!other.CompareTag("Platform") && !other.CompareTag("Player"))
        {
            Destroy(other);
        }
    }
}
