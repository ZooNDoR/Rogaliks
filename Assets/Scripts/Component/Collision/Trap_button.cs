using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_button : MonoBehaviour
{
    public bool click = false;
    public AudioSource klick;
    public SpriteRenderer sprite_rend;
    private Sprite[] sprites;
    void Awake() {
        sprites = Resources.LoadAll<Sprite>("Button");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if((click == false)&&(other.gameObject.tag == "Player")){
            sprite_rend.sprite = sprites[1];
            click = true;
            klick.Play();
            gameObject.transform.parent.gameObject.GetComponent<Room_info>().Check_cleared();
        }
    }
}
