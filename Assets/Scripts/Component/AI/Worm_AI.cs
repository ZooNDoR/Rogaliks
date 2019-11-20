using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{
    private Entity entity;
    private Transform target;
    private Vector2 direction;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed = entity.speed;
    }

    // Update is called once per frame
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
        }
    }
}
