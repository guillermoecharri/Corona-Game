using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftSideWrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Virus" || collision.gameObject.tag == "Item")
        {
            collision.gameObject.transform.position = new Vector3(2.81f, collision.gameObject.transform.position.y, 0f);
        }
    }
}
