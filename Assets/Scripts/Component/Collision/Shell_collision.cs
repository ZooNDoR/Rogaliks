using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_collision : MonoBehaviour
{   
    public float time_of_living;
    public string owner;
    public float damage;
    private void Start() {
        time_of_living = Time.time + time_of_living;
    }
    private void FixedUpdate() {
        if(time_of_living < Time.time)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(owner == "Player"){
            if (other.gameObject.tag == "Monster")
            {
                other.gameObject.GetComponent<Entity>().Stat_changed("health",-damage);
                GameObject.FindWithTag("Player").GetComponent<Entity>().destroy_shell.Play();
                Destroy(gameObject);
            }
        }
        if (owner == "Monster")
        {
             if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Entity>().Stat_changed("health",-damage);
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Room"){
            GameObject.FindWithTag("Player").GetComponent<Entity>().destroy_shell.Play();
            Destroy(gameObject);
        }
    }
}
