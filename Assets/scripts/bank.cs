using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;
public class bank : MonoBehaviour
{
    [SerializeField] private int startbalance = 250;
    [SerializeField] private int scorebalance = 500;

    [SerializeField] private TextMeshProUGUI displaybalance;
    [SerializeField] private TextMeshProUGUI displayscore;

    private int curbalance;
    public int currbalance
    {
        get { return curbalance; }
    }


    private void Start()
    {
        displayscore.text = Convert.ToString(scorebalance);
        curbalance = startbalance;
        UpdateBalance();
    }
    public void deposit(int value)
    {
        curbalance += Mathf.Abs(value);
        UpdateBalance();

        if (curbalance >= scorebalance)
        {
            LoadNextLevel();
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

    void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void UpdateBalance()
    {
        displaybalance.text = Convert.ToString(curbalance);
    }

}
