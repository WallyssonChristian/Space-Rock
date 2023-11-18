using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudScript : MonoBehaviour {

    public Text textPoint;
    private int points = 0;

    public void addPoints(int i){
        this.points += i;
        this.textPoint.text = points.ToString();
        if ((points% 1000) == 0) {
            GameObject.Find("meteorCreator").GetComponent<meteorCreatorScript>().addtVelocity();
        }


    }



}
