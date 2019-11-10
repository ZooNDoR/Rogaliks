using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_camera : MonoBehaviour
{
    private Vector3 new_pos; 
    public GameObject Character;
    private Vector3 C_position = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate() {
        new_pos = Character.transform.position;
        new_pos.x = Mathf.Round(new_pos.x/8)*8;
        new_pos.y = Mathf.Round(new_pos.y/5)*5;
        new_pos.z = -2f;
        transform.position = new_pos;
    }
}
