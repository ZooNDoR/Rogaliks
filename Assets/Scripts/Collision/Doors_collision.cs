using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Doors_collision : MonoBehaviour // Перемещает игрока меж комнатами
{
    public bool open = true;
    public AudioSource aud_pass_through;
    public AudioSource aud_unlock;
    public AudioSource aud_open;
    public AudioSource aud_close;
    public SpriteRenderer sprite_rend;
    private Sprite[] sprites;
    private bool locked = false;
    void Awake() {
        sprites = Resources.LoadAll<Sprite>("Doors");
    }
    void OnCollisionEnter2D(Collision2D other) {
        if((open == true) && (other.gameObject.tag == "Player")){
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
            GameObject.Find("logic").GetComponent<Checking_character_position>().Change_pos();
        }
    }
    public void Close()
    {
        if (!locked)
        {
            if (aud_close != null)
            aud_close.Play();
        sprite_rend.sprite = sprites[0];
        open = false;
        }
    }
    public void Open()
    {
        if (!locked)
        {
            sprite_rend.sprite = sprites[2];
        open = true;
        }
    }
    public void Lock(){
        sprite_rend.sprite = sprites[1];
        open = false;
        locked = true;
    }
    // void FixedUpdate() {
    //     Debug.Log(sprites.Length);
    //     if (Input.GetKey(KeyCode.E))
    //     {
            
    //     }
    //     if (Input.GetKey(KeyCode.R))
    //     {
    //         sprite_rend.sprite = sprites[1];
    //     }
    // }
}

