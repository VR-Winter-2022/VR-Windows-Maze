using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EndGame : MonoBehaviour
{
    public float prison_x=30F;
    public float prison_y = 30F;
    public float prison_z = 0;

    
    public int angle_x=30;
    public int angle_y = 30;
    public int angle_z = 0;
    public void Lose(){
        Text text_input = GameObject.Find("TimeText").GetComponent<Text>();
        text_input.text = "";
        this.transform.position = new Vector3(prison_x, prison_y-this.transform.position.y, prison_z);
        this.transform.eulerAngles = new Vector3(angle_x,angle_y,angle_z);

    }

}