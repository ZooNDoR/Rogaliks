using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 direction;
    public Entity entity;
    private float step;
    private float last_step;
    private float x,y;
    
    // Start is called before the first frame update
    void Start()
    {
        step = 1/entity.speed;
        last_step = Time.time;
        rb = GetComponent<Rigidbody2D> ();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Attack();
    }
    void Movement(){
        direction = new Vector2(0,0);
        if(Input.GetKey(KeyCode.W))
            direction += new Vector2(0,1f*entity.speed);
        if(Input.GetKey(KeyCode.S))
            direction += new Vector2(0,-1f*entity.speed);
        if(Input.GetKey(KeyCode.D))
            direction += new Vector2(1f*entity.speed,0);
        if(Input.GetKey(KeyCode.A))
            direction += new Vector2(-1f*entity.speed,0);
        if (direction != Vector2.zero)
        {   
            if ((last_step + step) < Time.time)
            {
                entity.aud_move.Play();
                last_step = Time.time;
            }
            
            rb.AddForce(direction);
        }
        // direction = new Vector2(0,0);
        // x = Input.GetAxis("Move_horizontal")*entity.speed;
        // y = Input.GetAxis("Move_vertical")*entity.speed;
        // direction += new Vector2(x,y);
        // rb.AddForce(direction);
    }
    void Attack()
    {
        if (Input.GetKey("up"))
            entity.attack_system.Fire(transform.position, new Vector2(0,2f));
        if (Input.GetKey("down"))
            entity.attack_system.Fire(transform.position, new Vector2(0,-2f));
        if (Input.GetKey("right"))
            entity.attack_system.Fire(transform.position, new Vector2(2f,0));
        if (Input.GetKey("left"))
            entity.attack_system.Fire(transform.position, new Vector2(-2f,0));
    }
}

