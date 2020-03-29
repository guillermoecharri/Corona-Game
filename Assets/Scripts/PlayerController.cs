using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    [SerializeField] float speed = 1;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //Mobile
        if(Input.touchCount > 0)
        {
            Vector3 touchesPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            animator.SetBool("isRunning", true);

            if (touchesPosition.x < 0) //move left
            {
                MoveLeft();
                
            }
            else //move right
            {
                MoveRight();
            }
        }
        else {
            animator.SetBool("isRunning", false);

            //For Testing On PC
            if (Input.GetAxis("Horizontal") != 0)
            {

                animator.SetBool("isRunning", true);

                if (Input.GetAxis("Horizontal") < 0)//move left
                {
                    MoveLeft();
                }
                else if (Input.GetAxis("Horizontal") > 0)//move right
                {
                    MoveRight();
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }

        
    }

    private void MoveLeft()
    {
        player.transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
        if (movingRight)
        {
            movingRight = false;
            gameObject.transform.Rotate(0, 180, 0);
        }
    }

    private void MoveRight()
    {
        if (!movingRight)
        {
            movingRight = true;
            gameObject.transform.Rotate(0, 180, 0);
        }
        player.transform.position += new Vector3((speed * Time.deltaTime), 0, 0);
    }
}
