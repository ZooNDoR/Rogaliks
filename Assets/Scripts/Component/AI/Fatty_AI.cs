using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty_AI : MonoBehaviour
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

    // Update is called once per frame
    void FixedUpdate()
    {   if(entity.enable == true){
        direction = new Vector2(0,0);
        direction += new Vector2(Coord(target.position.x,transform.position.x)*speed,Coord(target.position.y,transform.position.y)*speed);
        rb.AddForce(direction);
        }
    }
    float Coord(float a, float b)
    {
        if(a==b)
            return 0;
        else if (a<b)
            return -1;
        else
            return 1;
    }
}
