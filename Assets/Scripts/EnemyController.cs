using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0;
    [SerializeField] float minSpeed = 1;
    [SerializeField] float maxSpeed = 2;
    [SerializeField] float damage = 20;
    private bool isGrounded = false;
    private bool facingLeft = false;
    [SerializeField] Animator animator;
    [SerializeField] Animator outlineAnimator;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        animator.SetBool("isRunning", true);
        outlineAnimator.SetBool("isRunning", true);
    }

    void FixedUpdate()
    {
        Move();
    }

    public void SetIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    public void TurnAround()
    {
        facingLeft = !facingLeft;
        this.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void Move()
    {
        if (isGrounded)
        {
            if (facingLeft)
            {
                //move left
                this.transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
            }
            else
            {
                //move right
                this.transform.position += new Vector3((speed * Time.deltaTime), 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().damage(damage);
            collision.gameObject.GetComponent<PlayerHealth>().StartInvincibility();
        }
        else
        {
            //Debug.Log("Collided with: " + collision.gameObject.transform.root.name.ToString());
        }
    }
}
