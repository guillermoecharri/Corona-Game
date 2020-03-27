using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    private GameObject scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreboard.GetComponent<Score>().AddToiletPaper(1);
            //scoreboard.AddToiletPaper(1);
            Destroy(gameObject);
        }
    }
}
