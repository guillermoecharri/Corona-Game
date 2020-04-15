using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalMovement;
    [SerializeField] float speed = 2;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] Animator outlineAnimator;
    private bool movingRight = true;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //Mobile
        if(Input.touchCount > 0 && alive)
        {
            Vector3 touchesPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            animator.SetBool("isRunning", true);
            outlineAnimator.SetBool("isRunning", true);

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
            outlineAnimator.SetBool("isRunning", false);

            //For Testing On PC
            if (Input.GetAxis("Horizontal") != 0 && alive)
            {

                animator.SetBool("isRunning", true);
                outlineAnimator.SetBool("isRunning", true);

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
                outlineAnimator.SetBool("isRunning", false);
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

    public void SetAlive(bool alive)
    {
        this.alive = alive;
    }
}
