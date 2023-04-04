using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;
public class bank : MonoBehaviour
{
    [SerializeField] private int startbalance = 250;
    [SerializeField] private TextMeshProUGUI displaybalance;

    private int curbalance;
    public int currbalance
    {
        get { return curbalance; }
    }


    private void Start()
    {
        curbalance = startbalance;
        UpdateBalance();
    }
    public void deposit(int value)
    {
        curbalance += Mathf.Abs(value);
        UpdateBalance();

        if (curbalance > 500)
        {
            RestartScene();
        }

    }

    public void withdraw(int value)
    {
        UpdateBalance();
        curbalance -= Mathf.Abs(value);
        if (curbalance <= 0)
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateBalance()
    {
        displaybalance.text = Convert.ToString(curbalance);
    }

}
