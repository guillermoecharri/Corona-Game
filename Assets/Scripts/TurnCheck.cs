using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCheck : MonoBehaviour
{
    private GameObject enemy;

    private void Start()
    {
        enemy = this.transform.parent.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            enemy.GetComponent<EnemyController>().TurnAround();
        }
    }
}
