using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public TriggerController enemyVision;
    public PlayerMovementController player;
    public Rigidbody enemyRb;
    public Transform enemyBody;
    public float enemyMoveSpd;
    public float enemyAttackStr;
    public bool enemyAggroed;
    public float enemyHP;

    public void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.constraints = RigidbodyConstraints.FreezeRotation;
        enemyBody = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovementController>();
        enemyAggroed = false;
    }

    public void Update()
    {
        IsEnemyAggroed();
        EnemyChasePlayer();
        EnemyStatus();
    }

    public void IsEnemyAggroed()
    {
       if (enemyVision.triggerEntered && !enemyAggroed)
        {
            Debug.Log("Enemy Detected Player");
            enemyAggroed = true;
        }
    }

    public void EnemyChasePlayer()
    {
        if (enemyAggroed)
        {
            Vector3 moveDir = player.playerTransform.position - transform.position;
            enemyBody.forward = moveDir.normalized;
            enemyRb.AddForce(moveDir.normalized * enemyMoveSpd);
        }
    }

    void EnemyStatus()
    {
        if (enemyHP <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy HP below zero. destroying enemy");
        }
    }

    public void DamageEnemy(float damage)
    {
        enemyHP -= damage;
        Debug.Log("Enemy took " + damage + " points of damage");
    }
}