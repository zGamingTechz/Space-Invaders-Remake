using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public float speed = 3f;
    public float attack_Timer = -1f;
    private float current_Attack_Timer;
    private bool canAttack;
    public float deactivateTimer = 10f;
    public int score = 10;

    public GameObject Explosion_effect;
    [SerializeField]
    private Transform attack_Point;

    [SerializeField]
    private GameObject enemy_Bullet;


    void OnTriggerEnter2D()
    {
        Instantiate(Explosion_effect, attack_Point.position, Quaternion.identity);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deactivateTimer -= Time.deltaTime;

        if (deactivateTimer <= 0)
        {
            Destroy(gameObject);
        }

        Move();
        Attack();
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if (canAttack)
        {
            canAttack = false;
            attack_Timer = -2f;

            Instantiate(enemy_Bullet, attack_Point.position, Quaternion.identity);

            //play sound fx
        }
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
}
