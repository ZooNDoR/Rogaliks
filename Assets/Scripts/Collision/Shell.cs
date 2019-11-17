using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{   
    public string owner;
    public float damage;
    void OnTriggerEnter2D(Collider2D other) {
        if(owner == "Player"){
            if (other.gameObject.tag == "Monster")
            {
                other.gameObject.GetComponent<Entity>().Stat_changed("health",-damage);
                GameObject.FindWithTag("Player").GetComponent<Entity>().destroy_shell.Play();
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
