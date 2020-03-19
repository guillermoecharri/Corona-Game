using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthMax = 100;
    [SerializeField] float health = 100;

    public float GetHealthMax()
    {
        return healthMax;
    }

    public float GetHealth()
    {
        return health;
    }

    public void damage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0) //TODO!!!!!!!!!!!!!!!
        {
            Debug.Log("Game Over!");
            //To do: Change scene to main menu or something
        }
    }
}
