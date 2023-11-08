using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;

    public float min_y,max_y;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private GameObject advance_Player_Bullet;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.36f;
    private float current_Attack_Timer;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_y)
            {
                temp.y = max_y;
            }

            transform.position = temp;  
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_y)
            {
                temp.y = min_y;
            }

            transform.position = temp;
        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if (Input.GetKey(KeyCode.K))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = -0.15f;

                if (ActualScore.scoreForChangingBullets < 500)
                {
                    Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                }
                else if(ActualScore.scoreForChangingBullets >= 500)
                {
                    Instantiate(advance_Player_Bullet, attack_Point.position, Quaternion.identity);
                }

                //play sound fx
            }
        }
    }
}
