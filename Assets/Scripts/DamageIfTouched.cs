using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIfTouched : MonoBehaviour
{
    [SerializeField] bool instantDamage = false;
    [SerializeField] bool destoryAfterDamage = false;
    [SerializeField] float damage = 40;
    [SerializeField] bool doDamage = false;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doDamage == true)
        {
            player.GetComponent<PlayerHealth>().damage(damage * Time.deltaTime);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (instantDamage == false)
    //    {
    //        if (collision.gameObject.tag == "Player")
    //        {
    //            collision.gameObject.GetComponent<PlayerHealth>().damage(damage * Time.deltaTime);
    //        }
    //    }   
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(instantDamage == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().damage(damage);

                if (destoryAfterDamage == true)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if(collision.gameObject.tag == "Player")
            {
                doDamage = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doDamage = false;
    }
}
