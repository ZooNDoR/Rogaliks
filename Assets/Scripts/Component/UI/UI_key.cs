using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_key : MonoBehaviour
{
    public Text amount;
    public void Change_key_amount(int how_many){
        amount.text = "x" + how_many;
    }
}
