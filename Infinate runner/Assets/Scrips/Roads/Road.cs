using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public RoadSpawner rs;
    public GameObject road;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Debug.Log("PlayerHit");
           rs.SpawnRoad();
           DeleteRoad();
       }
    }

    public void DeleteRoad()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(4);

        Destroy(road);
    }
}
