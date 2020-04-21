using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField] GameObject itemGrab;
    [SerializeField] GameObject AudioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().GiveMaskInvincibility();
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
