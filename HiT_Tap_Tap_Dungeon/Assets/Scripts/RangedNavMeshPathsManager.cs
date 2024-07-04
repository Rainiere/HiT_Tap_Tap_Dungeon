using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedNavMeshPathsManager : MonoBehaviour
{

    public GameObject[] WaypointsList;
    private GameObject EnemyObject;
    private RangedEnemy enemy;
    private GameObject Player;  
    // Start is called before the first frame update
    void Start()
    {
        EnemyObject = GameObject.FindGameObjectWithTag("Enemy");
        enemy = EnemyObject.GetComponent<RangedEnemy>();
        Player = enemy.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 ReturnNextWaypoint(int CurrentWaypoint)
    {
        if(WaypointsList.Length-2 >= CurrentWaypoint){
            return WaypointsList[CurrentWaypoint + 1].transform.position;
        } else
        {
            CurrentWaypoint = 0;
            return WaypointsList[CurrentWaypoint].transform.position;
        }
    }
}
