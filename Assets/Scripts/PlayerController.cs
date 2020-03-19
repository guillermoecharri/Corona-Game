using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    [SerializeField] float speed = 1;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Vector3 touchesPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

            if (touchesPosition.x < 0) //move left
            {
                player.transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
            }
            else //move right
            {
                player.transform.position += new Vector3((speed * Time.deltaTime), 0, 0);
            }
        }
        else //for testing on PC
        {
            if (Input.GetAxis("Horizontal") < 0)//move left
            {
                player.transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0)//move right
            {
                player.transform.position += new Vector3((speed * Time.deltaTime), 0, 0);
            }
        }
    }
}
