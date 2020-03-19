using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaCloudController : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] float speed;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float dps = 10;
    [SerializeField] Score score;
    private bool playerIsInCloud;

    // Start is called before the first frame update
    void Start()
    {
        playerIsInCloud = false;
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
        } 
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
