using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int Speed; //Movement speed of Enemy;


    [HideInInspector] public GameObject Player;
    private Rigidbody EnemyRB; //Enemy RigidBody, old, maybe some use later??
    private NavMeshAgent EnemyNMA; //Enemy Nav Mesh Agent component

    [SerializeField] private GameObject NavMeshPath;
    private NavMeshPathsManager _NavMPManager; //NavMeshPathsManager reference
    private int CurrentWaypoint = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        _NavMPManager = NavMeshPath.GetComponent<NavMeshPathsManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyNMA = GetComponent<NavMeshAgent>();
        EnemyNMA.speed = Speed;
        EnemyNMA.SetDestination(_NavMPManager.ReturnNextWaypoint(CurrentWaypoint));

    }

    // Update is called once per frame
    void Update()
    {
        //if (EnemyNMA.speed < Speed * 2)
        //{
        //    EnemyNMA.speed += Time.deltaTime;
        //}
        Move();
    }

    private void Move()
    {
        if (EnemyNMA.remainingDistance <= 0.5)
        {
            EnemyNMA.SetDestination(_NavMPManager.ReturnNextWaypoint(CurrentWaypoint));
            CurrentWaypoint++;
        }
    }
}
