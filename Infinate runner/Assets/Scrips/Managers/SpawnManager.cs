using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public ObsticleSpawner[] os;
    public float[] howManySpawns;
    public float delay = 1f;
    float time;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if (time >= delay)
        {
            time = 0f;
            SpawnRandomObstical();
        }
    }

    public void SpawnRandomObstical()
    {
        int randomAmount = Random.Range(0, howManySpawns.Length);


        int random1 = Random.Range(0, os.Length);
        int random2 = Random.Range(0, os.Length);

        if(randomAmount == 0)
        {
            os[random1].GetComponent<ObsticleSpawner>().Spawn();
        }
        else 
        {
            if (random1 == random2)
            {
                random1 = Random.Range(0, os.Length);
            }
            else if (random2 == random1)
            {
                random2 = Random.Range(0, os.Length);
            }
            else
            {
                return;
            }

            os[random1].GetComponent<ObsticleSpawner>().Spawn();
            os[random2].GetComponent<ObsticleSpawner>().Spawn();
        }

        
    }

    }
