using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 direction;
    private Entity entity;
    private float step_time;
    private float last_step_time;
    private float x,y;
    
    private KeyCode move_up;
    private KeyCode move_down;
    private KeyCode move_right;
    private KeyCode move_left;

    private KeyCode fire_up;
    private KeyCode fire_down;
    private KeyCode fire_right;
    private KeyCode fire_left;

    // Start is called before the first frame update
    void Start()
    {
        Key_assignment();
        entity = GetComponent<Entity> ();
        rb = GetComponent<Rigidbody2D> ();
        step_time = 1.3f/entity.speed;
        last_step_time = Time.time;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Attack();
    }
    void Movement(){
        direction = new Vector2(0,0);
        if(Input.GetKey(move_up))
            direction += new Vector2(0,1f*entity.speed);
        if(Input.GetKey(move_down))
            direction += new Vector2(0,-1f*entity.speed);
        if(Input.GetKey(move_right))
            direction += new Vector2(1f*entity.speed,0);
        if(Input.GetKey(move_left))
            direction += new Vector2(-1f*entity.speed,0);
        if (direction != Vector2.zero)
        {   
            if ((last_step_time + step_time) < Time.time)
            {
                entity.aud_move.Play();
                last_step_time = Time.time;
            }
            rb.AddForce(direction);
        }
    }
    void Attack()
    {
        if (Input.GetKey(fire_up))
            entity.attack_system.Fire(transform.position, new Vector2(0,2f));
        if (Input.GetKey(fire_down))
            entity.attack_system.Fire(transform.position + new Vector3(0,-0.1f,0), new Vector2(0,-2f));
        if (Input.GetKey(fire_right))
            entity.attack_system.Fire(transform.position, new Vector2(2f,0));
        if (Input.GetKey(fire_left))
            entity.attack_system.Fire(transform.position, new Vector2(-2f,0));
    }
    void Key_assignment(){
        move_up     =   KeyCode.W;
        move_down   =   KeyCode.S;
        move_right  =   KeyCode.D;
        move_left   =   KeyCode.A;
        fire_up     =   KeyCode.UpArrow;
        fire_down   =   KeyCode.DownArrow;
        fire_right  =   KeyCode.RightArrow;
        fire_left   =   KeyCode.LeftArrow;
    }
    void Key_assignment(KeyCode m_up, KeyCode m_down,KeyCode m_right, KeyCode m_left, KeyCode f_up, KeyCode f_down,KeyCode f_right, KeyCode f_left){
        move_up     =   m_up;
        move_down   =   m_down;
        move_right  =   m_right;
        move_left   =   m_left;
        fire_up     =   f_up;
        fire_down   =   f_down;
        fire_right  =   f_right;
        fire_left   =   f_left;
    }
}

