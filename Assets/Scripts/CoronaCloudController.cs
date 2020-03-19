﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaCloudController : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] float speed;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float dps = 10;
    [SerializeField] Score score;
    [SerializeField] GameObject[] platforms;
    private float platTracker = 0;
    private static int platformBufferSize = 12; //all the platform layers loaded at once
    private GameObject[] activePlatforms = new GameObject[platformBufferSize];
    private bool playerIsInCloud;

    // Start is called before the first frame update
    void Start()
    {
        playerIsInCloud = false;

        for(int i = 0; i < platformBufferSize; i++)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y -= i + 1;
            activePlatforms[i] = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (playerIsInCloud)
        {
            playerHealth.damage(dps * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsInCloud)
        {
            float movement = speed * Time.deltaTime;
            //move the cloud
            cloud.transform.position = new Vector3(0, cloud.transform.position.y - movement, 0);
            //add to score
            score.Add(movement);
            //increment platTracker
            platTracker += movement;
            if(platTracker >= 1)
            {
                platTracker -= 1;
                UpdatePlatforms();
            }
        } 
    }

    private void UpdatePlatforms()
    {
        Destroy(activePlatforms[0]);
        for(int i = 0; i < platformBufferSize - 1; i++)
        {
            activePlatforms[i] = activePlatforms[i + 1];
        }
        Vector3 pos = gameObject.transform.position;
        pos.y -= platformBufferSize;
        Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stop moving the cloud
        playerIsInCloud = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsInCloud = false;
    }

}
