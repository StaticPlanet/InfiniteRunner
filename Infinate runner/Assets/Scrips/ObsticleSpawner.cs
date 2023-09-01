using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject[] obsticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        int randomIndex = Random.Range(0, obsticle.Length);
        Instantiate(obsticle[randomIndex], transform.position, transform.rotation);
    }
}
