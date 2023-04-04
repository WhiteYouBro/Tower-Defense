using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private int reward = 25;
    [SerializeField] private int goladpenalty = 25;
    [SerializeField] private int damage = 30;

    private bank _bank;

    private void Start()
    {
        _bank = FindObjectOfType<bank>();
    }

    public void RewardGold()
    {
        if (_bank == null) return;
        _bank.deposit(reward);
    }
    public void PenaltyGold()
    {
        if (_bank == null) return;
        _bank.withdraw(goladpenalty);
    }
    public void damagecastle()
    {
        _bank.withdraw(damage);
    }
}
