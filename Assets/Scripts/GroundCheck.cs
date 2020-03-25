using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private GameObject enemy;

    private void Start()
    {
        enemy = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            enemy.GetComponent<EnemyController>().SetIsGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            enemy.GetComponent<EnemyController>().SetIsGrounded(false);
        }
    }
}
