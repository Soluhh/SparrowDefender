using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] float enemyHealth = 100f;
    [SerializeField] float enemyKillHealth = 0f;
    [SerializeField] float playerDamage = 20f;
    ScoreBoard scoreBoard;
    Rigidbody rb;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        enemyHealth -= playerDamage;
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(hitVFX, transform.position,Quaternion.identity);
        vfx.transform.parent = parent;
        Debug.Log(enemyHealth);
    }

    void KillEnemy()
    {
        if(enemyHealth == enemyKillHealth)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
        }
    }
}
