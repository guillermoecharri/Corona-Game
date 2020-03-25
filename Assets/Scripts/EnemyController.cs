using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject enemy;
    private bool isGrounded = false;
    private bool facingLeft = false;

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
}
