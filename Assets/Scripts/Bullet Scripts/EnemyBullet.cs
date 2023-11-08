using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 3.1f;

    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deactivate_timer -= Time.deltaTime;

        if (deactivate_timer <= 0)
        {
            Destroy(gameObject);
        }

        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
}
