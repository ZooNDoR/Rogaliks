using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_collision : MonoBehaviour
{
    // public GameObject other;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            switch(name){
                case "up_door":
                other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y+1.8f,other.transform.position.z);
                break;
                case "down_door":
                other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y-1.8f,other.transform.position.z);
                break;
                case "left_door":
                other.transform.position = new Vector3(other.transform.position.x-1.7f,other.transform.position.y,other.transform.position.z);
                break;
                case "right_door":
                other.transform.position = new Vector3(other.transform.position.x+1.7f,other.transform.position.y,other.transform.position.z);
                break;
            }
        }
    }  
}

