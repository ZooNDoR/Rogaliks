using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_info : MonoBehaviour
{
    public string room_name;
    public bool cleared; // Обозначает пройдена ли комната(все ли монстры убиты и т.д.)
    private GameObject clild_obj; // Потомок(Монстр)
    private GameObject door;
    public GameObject[] drop;
    public Random rnd = new Random();

    private void Start() {
        switch (room_name)
        {
            case "Monster_room": cleared = false; break;
            case "Trap_room": cleared = false; break;
            default: cleared = true; break;
        }
    }

    public void Check_cleared(){
        foreach(Transform child in transform)
        {
            if(child.tag == "Monster")
                return;
            if(child.tag == "Trap_button")
            {
                if(child.GetComponent<Trap_button>().click == false)
                    return;
            }
        }
        if(room_name == "Monster_room")
            Drop_rand_item();
        Open_door();
    }
    void Drop_rand_item()
    {
        var droped = Instantiate(drop[Random.Range(0, drop.Length)], transform.position + new Vector3(0,0,-0.5f) , Quaternion.identity);
        droped.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50f, 50f),Random.Range(-50f, 50f)));
    }
    void OnTransformChildrenChanged()
    {
        Check_cleared();
    }
    public void Close_door(){
        foreach(Transform child in transform)
        {
            if(child.tag == "Door"){
                child.GetComponent<Doors_collision>().Close();
            }
        }
    }
    public void Open_door(){
        cleared = true;
        foreach(Transform child in transform)
        {
            if(child.tag == "Door"){
                child.GetComponent<Doors_collision>().Open();
            }
        }
    }
    public void Enable_monsters()
    {
        foreach(Transform child in transform)
            {
                if(child.tag == "Monster")
                    child.GetComponent<Entity>().Enable_entity();
            }
    }
    public void Lock_door(string door_name){
        foreach(Transform child in transform)
        {
            if((child.tag == "Door") && (child.name == door_name)){
                child.GetComponent<Doors_collision>().Lock();
            }
        }
    }
    
}
