using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCloud : MonoBehaviour
{
    [SerializeField] GameObject parent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //move player with the platform
            collision.gameObject.transform.parent = parent.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //stop moving player with the platform
            collision.gameObject.transform.parent = null;
        }
    }
}
