using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_system : MonoBehaviour { // Система атаки. Основной метод Fire() вызывается, когда юнит "хочет" выстрелить

    // Start is called before the first frame update
    public string attack_type;  // Тип атаки
    public GameObject shell;
    private GameObject created_shell;
    private Entity entity;
    private float last_fire;
    private Rigidbody2D rb_shell;
    // Update is called once per frame
    
    void Start() {
        entity = GetComponent<Entity> ();
        last_fire = Time.time;
    }
    public void Fire(Vector3 position,Vector2 direction){    // Выстреливает из position в сторону direction
        // if(attack_type == "Range"){
            if ((last_fire + (6/entity.attack_speed))  < Time.time)
            {
                entity.range_attack.Play();
                created_shell = Instantiate(shell,position,Quaternion.identity);
                created_shell.GetComponent<Shell>().damage = entity.damage;
                created_shell.GetComponent<Shell>().owner = gameObject.tag;
                created_shell.GetComponent<Rigidbody2D>().AddForce(direction);
                last_fire = Time.time;
            }   
        // }
    }
    void OnCollisionStay2D(Collision2D other) { // Вызывается каждый кадр при столкновении с чемнибу-дь
        if((attack_type == "Melee") || (attack_type == "Hybrid")) // Если тип атаки - рукопашный или гибрид
        {
            if ((last_fire + (6/entity.attack_speed))  < Time.time)    // Если прошлло больше времени, чем скорость атаки
            {
                switch (other.gameObject.tag){  // Приверяем с чем столкнулись
                    case "Player":
                    other.gameObject.GetComponent<Entity>().Stat_changed("health",-entity.damage);
                    last_fire = Time.time;
                    break;
                    default:break;
                }
            }
        }
    }
}
