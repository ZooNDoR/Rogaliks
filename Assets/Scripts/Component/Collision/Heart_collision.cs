using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_collision : MonoBehaviour
{
    private Entity entity;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            entity = other.gameObject.GetComponent<Entity>();
            if (entity.health < entity.max_health)
            {
                entity.Stat_changed("health",1f);
                Destroy(gameObject);
            }
        }
    }
}
