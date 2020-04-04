using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [SerializeField] private bool wrapPlayer = false;
    [SerializeField] private bool wrapEnemies = false;
    [SerializeField] private bool wrapItems = false;
    [SerializeField] private bool wrapViruses = false;
    [SerializeField] private bool wrapClouds = false;
    [SerializeField] private GameObject objectToWrapTo = null;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && wrapPlayer == true)
        {
            TeleportGameObjectToPosition(collision.gameObject);
        }
        if(collision.tag == "Enemy" && wrapEnemies == true)
        {
            TeleportGameObjectToPosition(collision.gameObject);
        }
        if (collision.tag == "Item" && wrapItems == true)
        {
            TeleportGameObjectToPosition(collision.gameObject);
        }
        if (collision.tag == "Virus" && wrapViruses == true)
        {
            TeleportGameObjectToPosition(collision.gameObject);
        }
        if (collision.tag == "Cloud" && wrapClouds == true)
        {
            TeleportGameObjectToPosition(collision.gameObject);
        }
    }

    private void TeleportGameObjectToPosition(GameObject collision)
    {
        float xPos = objectToWrapTo.transform.position.x + xOffset;
        float yPos = collision.transform.position.y + yOffset;
        float zPos = collision.transform.position.z + zOffset;
        collision.transform.position = new Vector3(xPos, yPos, zPos);
    }
}
