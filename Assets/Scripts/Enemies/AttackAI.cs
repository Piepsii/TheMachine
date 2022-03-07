using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AttackAI : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float interval = 0.5f;
    [SerializeField]
    private bool ranged = false;
    [SerializeField]
    private GameObject projectilePrefab;

    private PlayerHealth player;
    private GameObject enemy;
    private Vector2 vectorToPlayer;
    private float rotationZ;
    private bool inRange;

    private IEnumerator meleeCoroutine;
    private IEnumerator rangedCoroutine;

    public GameObject AttackPlayerSoundEffectPrefab;
    public GameObject FiringSoundEffectPrefab;

    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemy = transform.parent.gameObject;
        animator = enemy.GetComponentInChildren<Animator>();
        inRange = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ranged)
            {
                enemy.GetComponent<AIPath>().canMove = false;
                enemy.GetComponent<Rigidbody2D>().drag = 1000;
                rangedCoroutine = Shoot(rotationZ);
                inRange = true;
                StartCoroutine(rangedCoroutine);
            }
            else
            {
                meleeCoroutine = Attack();
                inRange = true;
                StartCoroutine(meleeCoroutine);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ranged)
            {
                enemy.GetComponent<AIPath>().canMove = true;
                enemy.GetComponent<Rigidbody2D>().drag = 1;
                StopCoroutine(rangedCoroutine);
                inRange = false;
            }
            else
            {
                StopCoroutine(meleeCoroutine);
                inRange = false;
            }
        }
    }

    IEnumerator Shoot(float rotationZ)
    {
        while (inRange)
        {
            vectorToPlayer = player.transform.position - transform.position;
            rotationZ = Mathf.Atan2(vectorToPlayer.y, vectorToPlayer.x) * Mathf.Rad2Deg;
            animator.SetBool("IsShooting", true);
            yield return new WaitForSeconds(interval);
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            projectile.GetComponent<EnemyProjectileDamage>().Damage = damage;

            if (FiringSoundEffectPrefab != null)
                Instantiate(FiringSoundEffectPrefab);
        }
    }

    IEnumerator Attack()
    {
        while (inRange)
        {
            animator.SetBool("IsAttacking", true);
            yield return new WaitForSeconds(interval);
            player.reduceHealth(damage);

            if (AttackPlayerSoundEffectPrefab != null)
                Instantiate(AttackPlayerSoundEffectPrefab);
        }
    }
}
