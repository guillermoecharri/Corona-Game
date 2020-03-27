using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIfTouched : MonoBehaviour
{
    [SerializeField] bool instantDamage = false;
    [SerializeField] bool destoryAfterDamage = false;
    [SerializeField] float damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (instantDamage == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().damage(damage * Time.deltaTime);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().damage(damage);

            if(destoryAfterDamage == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
