using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch_collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameObject.Find("logic").GetComponent<Score_manager>().Add_score(200);
            GameObject.Find("logic").GetComponent<Generator>().New_level();
            
        }
    }
}
