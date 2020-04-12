using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthMax = 100;
    [SerializeField] float health = 100;
    [SerializeField] float invincibilityLength = 3.0f;
    [SerializeField] float handSanitizerInvincibilityLength = 4.0f;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject coronaCloud;
    private float invincibilityCounter;

    private void Start()
    {
        invincibilityCounter = 0;
    }

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
        if (invincibilityCounter == 0)
        {
            health -= damage;
        }
    }

    private void Update()
    {
        if(invincibilityCounter > 0)
        {
            gameObject.layer = 9; //put into invincible layer
            invincibilityCounter -= Time.deltaTime;

            if(invincibilityCounter < 0)
            {
                invincibilityCounter = 0;
                gameObject.layer = 0; //put back in default layer
            }
            
        }

        if (health <= 0) //TODO!!!!!!!!!!!!!!!
        {
            health = 0;
            Debug.Log("Game Over!");
            //To do: Change scene to main menu or something
            deathMenu.SetActive(true);
            coronaCloud.GetComponent<CoronaCloudController>().centerOnDeath(gameObject.transform.position);
            gameObject.GetComponent<PlayerController>().SetAlive(false);
        }
    }

    public void StartInvincibility()
    {
        invincibilityCounter = invincibilityLength;
    }

    public void GiveHandSanitizerInvincibility()
    {
        invincibilityCounter = handSanitizerInvincibilityLength;
    }

    public bool GetIsInvincible()
    {
        if(invincibilityCounter > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
