using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject _roadPrefab;
    private List<GameObject> roads = new List<GameObject>();
    public float MaxSpeed = 10f;
    private float speed = 0f;
    public int maxRoadCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0f) return;

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < 1)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0) {pos = roads[roads.Count - 1].transform.position  + new Vector3(0,0,10);}
        GameObject go =  Instantiate(_roadPrefab, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }

    public void StartLevel()
    {
        speed = MaxSpeed;
    }



    public void ResetLevel()
    {
        speed = 0f;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }

        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }
}
