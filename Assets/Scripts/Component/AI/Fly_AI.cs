using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_AI : MonoBehaviour
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
        entity.aud_move.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(entity.enable == true)
        {
        entity.aud_move.mute = false;
        direction = new Vector2(0,0);
        direction += new Vector2(((target.position.x-transform.position.x)/speed),((target.position.y-transform.position.y)/speed));
        rb.AddForce(direction);
        }
    }
}
