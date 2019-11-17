using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool enable = true;
    public float max_health;
    public float health;
    public float damage;
    public float attack_speed;
    public float speed;

    public Attack_system attack_system;

    public AudioSource greeting;        // Приветствие
    public AudioSource aud_move;        // Перемещение
    public AudioSource health_down;     // Получение урона
    public AudioSource health_up;       // Выздоровление
    public AudioSource destroy_shell;   // Уничтожение снаряда
    public AudioSource range_attack;    // Выстрел
    public AudioSource melee_attack;    // Удар
    public AudioSource bite;            // Поедание
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Monster")
            enable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enable)
            Check_HP();
    }
    void Check_HP()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Stat_changed(string what, float how_much){ // Метод изменяющий характеристики сущности
        switch (what)
        {
            case "health":
            if(how_much > 0)
            {
                if(health_up != null)
                    health_up.Play();
            }
            else
            {
                if(health_down != null)
                    health_down.Play();
            }
            health += how_much;
            break;
            case "damage":
            damage += how_much;
            break;
            case "attack_speed":
            attack_speed += how_much;
            break;
            case "speed":
            speed += how_much;
            break;
            default:break;
        }
    }
    public void Bite()
    {
        bite.Play();
    }
    public void Enable_entity(){
        enable = true;
        if (greeting!=null)
            greeting.Play();
    }

}
