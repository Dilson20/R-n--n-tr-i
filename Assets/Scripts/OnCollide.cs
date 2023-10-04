using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollide : MonoBehaviour
{
    public int score;
    [SerializeField] private Material myMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food"||other.gameObject.tag == "FoodRed"||other.gameObject.tag == "FoodBlue"||other.gameObject.tag == "FoodYellow")
        {
            Debug.LogError("a");
            addScore();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FoodRed") 
        {
            myMaterial.color = Color.red;
        }
        if (other.gameObject.tag == "FoodBlue")
        {
            myMaterial.color = Color.blue;
        }
        if(other.gameObject.tag == "FoodYellow")
        { 
            myMaterial.color = Color.yellow;
        }
    }

    public void addScore() 
    {
        score++;
    }
}