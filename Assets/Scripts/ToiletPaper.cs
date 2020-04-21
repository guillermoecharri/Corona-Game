using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    private GameObject scoreboard;
    [SerializeField] GameObject itemGrab;
    [SerializeField] GameObject AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.FindGameObjectWithTag("Score");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreboard.GetComponent<Score>().AddToiletPaper(1);
            Instantiate(itemGrab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            PlayItemSound();
            Destroy(gameObject);
        }
    }

    private void PlayItemSound()
    {
        FindObjectOfType<AudioManager>().Play("Item");
    }
}
