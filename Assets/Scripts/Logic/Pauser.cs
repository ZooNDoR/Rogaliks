using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public GameObject aplication;
    public GameObject menu;
    public GameObject panel;
    private bool pause = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            if(pause == false)
                Pause_on();
            else
                Pause_off();
    }
    public void Pause_on(){
        pause = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void Pause_off(){
        pause = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void Return_main_menu(){
        pause = false;
        Time.timeScale = 1;
        GameObject.Find("logic").GetComponent<Generator>().ClearAll();
        panel.SetActive(false);
        menu.SetActive(true);
        aplication.SetActive(false);
    }
}
