using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    
    [SerializeField] private int Speed; //Movement speed of Enemy;


    [HideInInspector] public GameObject Player;
    private Rigidbody EnemyRB; //Enemy RigidBody, old, maybe some use later??
    private NavMeshAgent EnemyNMA; //Enemy Nav Mesh Agent component

    [SerializeField] private GameObject NavMeshPath;
    private RangedNavMeshPathsManager _NavMPManager; //NavMeshPathsManager reference
    private int CurrentWaypoint = 0;

    [SerializeField] private GameObject Projectile;
    [SerializeField] private int ProjectileSpeed;
    [SerializeField] private float ShootTimer;
    private float OriginalShootTimer;
    private bool HasShot = false;
    

    // Start is called before the first frame update
    void Start()
    {
        OriginalShootTimer = ShootTimer;
        _NavMPManager = NavMeshPath.GetComponent<RangedNavMeshPathsManager>();
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
        if (EnemyNMA.remainingDistance <= 0.5 && HasShot == false)
        {
            gameObject.transform.LookAt(Player.transform.position);
            ShootTimer -= Time.deltaTime;
            if (ShootTimer <= 0)
            {
                ShootProjectile();
                HasShot = true;
            }
        }
        if (HasShot == true)
        {
            CurrentWaypoint++;
            HasShot = false;
            ShootTimer = OriginalShootTimer;
            if (CurrentWaypoint >= _NavMPManager.WaypointsList.Length)
            {
                CurrentWaypoint = 0;
            };
            EnemyNMA.SetDestination(_NavMPManager.ReturnNextWaypoint(CurrentWaypoint));
        }
    }

    private void ShootProjectile()
    {
        GameObject ShotProjectile = Instantiate(Projectile, gameObject.transform.position, gameObject.transform.rotation);
        EnemyProjectile ProjectileScript = ShotProjectile.GetComponent<EnemyProjectile>();
        ProjectileScript.Speed = ProjectileSpeed;
    }


}
