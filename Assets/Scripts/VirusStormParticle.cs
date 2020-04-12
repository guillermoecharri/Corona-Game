using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusStormParticle : MonoBehaviour
{
    [SerializeField] private float speedMin = 0;
    [SerializeField] private float speedMax = 0;
    private float speed;

    private void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
