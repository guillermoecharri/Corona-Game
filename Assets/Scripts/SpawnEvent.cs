using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] int[] odds;
    [SerializeField] GameObject[] spawners;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        bool hasBadie = false;
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i].name == "Badie")
            {
                hasBadie = true;
            }
        }

        if(score.GetScore() > 1 || hasBadie == false) //don't spawn anything when the score is 0
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                Vector3 pos = spawners[i].transform.position;
                Instantiate(items[Randomizer()], pos, Quaternion.identity);
            }
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
