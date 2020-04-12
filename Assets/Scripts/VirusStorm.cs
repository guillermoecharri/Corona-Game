using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusStorm : MonoBehaviour
{
    [SerializeField] private int numParticles = 0;
    [SerializeField] private float yRange = 0;
    [SerializeField] private float xRange = 0;
    [SerializeField] private float minParticleSpeed = 0;
    [SerializeField] private float maxParticleSpeed = 0;
    [SerializeField] private GameObject stormParticle = null;
    [SerializeField] private GameObject virus1 = null;
    [SerializeField] private GameObject virus2 = null;

    void Awake()
    {
        float maxXPos = gameObject.transform.position.x + xRange / 2;
        float minXPos = gameObject.transform.position.x - xRange / 2;
        float maxYPos = gameObject.transform.position.y + yRange / 2;
        float minYPos = gameObject.transform.position.y - yRange / 2;

        for(int i = 0; i < numParticles; i++)
        {
            GameObject particle = Instantiate(stormParticle, new Vector3(0,0,0), Quaternion.identity);
            particle.transform.parent = gameObject.transform;
            particle.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
            particle.GetComponent<VirusStormParticle>().SetSpeed(Random.Range(minParticleSpeed, maxParticleSpeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}