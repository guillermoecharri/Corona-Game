using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject[] spawners;
    

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < spawners.Length; i++)
        {
            Vector3 pos = spawners[i].transform.position;
            Instantiate(items[Randomizer()], pos, Quaternion.identity);
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private int Randomizer() //for later use with more complex randomization when we have more items
    {
        int index = Random.Range(0, items.Length);
        return index;
    }

   
}
