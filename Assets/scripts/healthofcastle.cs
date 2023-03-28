using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class healthofcastle : MonoBehaviour
{
    [SerializeField] private TMP_Text textofhealth;
    //[SerializeField] private scrollbar scroll;
    public int health = 100;
    private void Update()
    {
        
        textofhealth.text = Convert.ToString(health);
        if (health <= 0)
        {
            print("вы умерли");
        }
    }
}
