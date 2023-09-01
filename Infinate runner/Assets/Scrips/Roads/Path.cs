using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject car;
    public GameObject[] path;
    public int numberOfPoints;
    public float speed = 3;

    private Vector3 actualPosition;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = car.transform.position;
        car.transform.position = Vector3.MoveTowards(actualPosition, path[x].transform.position, speed * Time.deltaTime);

        if(actualPosition == path[x].transform.position && x != numberOfPoints - 1) 
        {
            x++;
        }
    }

    public void destroy() 
    {
       Destroy(gameObject);
    }
}
