using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject[] drop;
    private GameObject droped;
    public void Drop_(Vector3 position, int how_many){
        for (int i = 0; i < how_many; i++)
            droped = Instantiate(drop[Random.Range(0,drop.Length)],new Vector3(position.x,position.y,position.z-0.1f),Quaternion.identity);
        if (droped.GetComponent<Rigidbody2D>())
            droped.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50f, 50f),Random.Range(-50f, 50f)));
    }
    public void Drop_(Vector3 position){    
        droped = Instantiate(drop[Random.Range(0,drop.Length)],new Vector3(position.x,position.y,position.z-0.1f),Quaternion.identity);
        if (droped.GetComponent<Rigidbody2D>())
            droped.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50f, 50f),Random.Range(-50f, 50f)));
    }
}
