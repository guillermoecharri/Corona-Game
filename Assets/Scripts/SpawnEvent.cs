using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] int[] odds;
    [SerializeField] GameObject[] spawners;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
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
        int roll = Random.Range(1, 101);
        int oddsCount = 0;
        for(int i = 0; i < odds.Length; i++)
        {
            if (roll <= odds[i] + oddsCount)
            {
                return i;
            }
            oddsCount += odds[i];
        }
        
        return 0;
    }


}
