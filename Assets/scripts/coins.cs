using System;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    [SerializeField] private int startcoinsvalue = 100;
    [SerializeField] private int increasecoin = 10;
    [SerializeField] private int maxcoinsvalue = 100;
    [SerializeField] private TMP_Text currentcoin;
    [SerializeField] private TMP_Text maxcoins;
    [HideInInspector] public int curcoins;
    private float times = 0;
    // Start is called before the first frame update
    void Start()
    {
        curcoins = startcoinsvalue;
    }

    // Update is called once per frame
    void Update()
    {
        maxcoins.text = Convert.ToString(maxcoinsvalue);
        currentcoin.text = Convert.ToString(curcoins);
        
        times += Time.deltaTime;
        if (times > 3 && curcoins <= maxcoinsvalue)
        {
            
            curcoins += increasecoin;
            if (curcoins + increasecoin >= maxcoinsvalue) 
                curcoins = maxcoinsvalue; 
            times = 0;  
        }
    }
}
