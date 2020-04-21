using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaCloudController : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] float startingSpeed = 1.0f;
    [SerializeField] private float speed;
    [SerializeField] float maxSpeed = 2.8f;
    [SerializeField] float speedScale = 200;
    //[SerializeField] PlayerHealth playerHealth;
    //[SerializeField] float dps = 10;
    [SerializeField] Score score;
    [SerializeField] GameObject[] platforms;
    private float platTracker = 0;
    private static int platformBufferSize = 12; //all the platform layers loaded at once
    private GameObject[] activePlatforms = new GameObject[platformBufferSize];
    private bool playerIsInCloud;
    [SerializeField] float spacingMultiplier = 3;
    [SerializeField] GameObject camera;
    private bool playerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = startingSpeed;
        playerIsInCloud = false;

        //for(int i = 0; i < platformBufferSize; i++)
        //{
        //    Vector3 pos = gameObject.transform.position;
        //    pos.y -= (i + 1) * spacingMultiplier;
        //    activePlatforms[i] = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
        //}
    }

    private void Update()
    {
        //if (playerIsInCloud)
        //{
        //    playerHealth.damage(dps * Time.deltaTime);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(speed < maxSpeed)
        {
            speed = startingSpeed + score.GetComponent<Score>().GetScore() / speedScale;
        }
        

        if (!playerIsInCloud && playerIsAlive)
        {
            float movement = speed * Time.deltaTime;
            //move the cloud
            cloud.transform.Translate(new Vector3(0, -movement, 0));
            //cloud.transform.position = new Vector3(0, cloud.transform.position.y - movement, 0);
            //add to score
            score.Add(movement);
            //increment platTracker
            //platTracker += movement;
            //if (platTracker >= spacingMultiplier)
            //{
            //    platTracker -= spacingMultiplier;
            //    UpdatePlatforms();
            //}
        } 
    }

    //private void UpdatePlatforms()
    //{
    //    Destroy(activePlatforms[0]);
    //    for(int i = 0; i < platformBufferSize - 1; i++)
    //    {
    //        activePlatforms[i] = activePlatforms[i + 1];
    //    }
    //    Vector3 pos = gameObject.transform.position;
    //    pos.y -= platformBufferSize * spacingMultiplier;
    //    Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //stop moving the cloud
            playerIsInCloud = true;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsInCloud = false;
    }

    public void centerOnDeath(Vector3 pos)
    {
        playerIsAlive = false; //set true for continue
        float movement = speed * Time.deltaTime;
        float threshhold = 1.0f;
        if (Mathf.Abs(pos.y - camera.transform.position.y) > threshhold)
        {
            if (pos.y < camera.transform.position.y)
            {
                cloud.transform.Translate(new Vector3(0, -movement, 0));
            }
            else if (pos.y > camera.transform.position.y)
            {
                cloud.transform.Translate(new Vector3(0, movement, 0));
            }
        }
       
    }

    public void PlayerRevived()
    {
        playerIsAlive = true;
    }

}
