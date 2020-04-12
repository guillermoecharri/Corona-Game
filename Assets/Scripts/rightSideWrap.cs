using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideWrap : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Item")
        {
            collision.gameObject.transform.position = new Vector3(-2.81f, collision.gameObject.transform.position.y, 0f);
        }
    }
}
