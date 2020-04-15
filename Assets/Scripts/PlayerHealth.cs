using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthMax = 100;
    [SerializeField] float health = 100;
    [SerializeField] float invincibilityLength = 3.0f;
    [SerializeField] float maskInvincibilityLength = 10.0f;
    private bool maskInvincibility = false;
    [SerializeField] GameObject mask;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject coronaCloud;
    [SerializeField] float flashingLength = 0; //How much time is left before the character should stop flashing from taking damage.
    [SerializeField] float flashingLengthMax = 3; //How long the character should flash upon taking damage. Flashing is done by enabling/disabling the sprite component.
    [SerializeField] float flashingFrequency = 0.5f;
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
            if (flashingLength == 0)
            {
                flashingLength = flashingLengthMax;
            }
        }
    }

    private void Update()
    {
        //Flashing
        if(flashingLength > 0 && health > 0)
        {
            //adjust based off time
            flashingLength -= Time.deltaTime;
            if(flashingLength < 0)
            {
                flashingLength = 0;
            }
            //determine if sprite should be flashing based on flashingLength and flashingFrequency
            bool spriteState;
            if(Mathf.RoundToInt(flashingLength / flashingFrequency) % 2 == 0)
            {
                spriteState = false;
            }
            else
            {
                spriteState = true;
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = spriteState;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        //Invisibility
        if(invincibilityCounter > 0)
        {
            gameObject.layer = 9; //put into invincible layer
            invincibilityCounter -= Time.deltaTime;

            if(invincibilityCounter < 0)
            {
                invincibilityCounter = 0;
                gameObject.layer = 0; //put back in default layer
                //remove mask if it's on
                if(maskInvincibility == true)
                {
                    maskInvincibility = false;
                    mask.SetActive(maskInvincibility);
                }
            }
            
        }

        //Death
        if (health <= 0) //TODO!!!!!!!!!!!!!!!
        {
            health = 0;
            flashingLength = 0;
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

    public void GiveMaskInvincibility()
    {
        invincibilityCounter = maskInvincibilityLength;
        maskInvincibility = true;
        mask.SetActive(maskInvincibility);
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

    public void Heal(float amount)
    {
        health += amount;
        if(health > healthMax)
        {
            health = healthMax;
        }
    }

    public void SetFullHealth()
    {
        health = healthMax;
    }
}
