using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightSideWrap : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-2.81f, collision.gameObject.transform.position.y, 0f);
        }
    }
}
