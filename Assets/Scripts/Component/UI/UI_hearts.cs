using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_hearts : MonoBehaviour
{
    private float x = 0;
    public void Change_hearts(float how_many)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach(Transform child in transform)
        {
            if(x >= how_many)
                break;
            child.gameObject.SetActive(true);
            x++;
        }
        x = 0;
    }
    // Start is called before the first frame update
}
