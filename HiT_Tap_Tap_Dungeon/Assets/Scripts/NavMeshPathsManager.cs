using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NavMeshPathsManager : MonoBehaviour
{

    [SerializeField] private GameObject[] WaypointsList;
    private GameObject EnemyObject;
    private Enemy enemy;
    private GameObject Player;  
    // Start is called before the first frame update
    void Start()
    {
        EnemyObject = GameObject.FindGameObjectWithTag("Enemy");
        enemy = EnemyObject.GetComponent<Enemy>();
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
            return Player.transform.position;
        }
    }
}
