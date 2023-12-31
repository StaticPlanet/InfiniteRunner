using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{

    public List<GameObject> roads;
    public float offset = 2.811115f;

    // Start is called before the first frame update
    void Start()
    {
        if (roads !=null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoaveRoad()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newZ = roads[roads.Count- 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(moveRoad);
    }
}
