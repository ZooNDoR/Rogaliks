using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider_AI : MonoBehaviour
{
    private Entity entity;
    private Transform target;
    private Vector2 direction;
    private Rigidbody2D rb;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed = entity.speed;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {   
        if(entity.enable == true)
        {
            direction = new Vector2(0,0);
            direction.x = target.position.x-transform.position.x;
            direction.y = target.position.y-transform.position.y;
            while ((Mathf.Abs(direction.x)>2) || (Mathf.Abs(direction.y)>2))
            {
                direction.x /= 2;
                direction.y /= 2;
            }
            entity.attack_system.Fire(transform.position, direction);

            direction = new Vector2(0,0);
            direction += new Vector2(((target.position.x-transform.position.x)/speed),((target.position.y-transform.position.y)/speed));
            rb.AddForce(direction);
        }
    }
}
