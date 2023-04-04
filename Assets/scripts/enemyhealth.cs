using UnityEngine;

[RequireComponent(typeof(enemy))]
public class enemyhealth : MonoBehaviour
{
    [SerializeField] private int maxhitpoints = 5;
    [SerializeField] private int healthramp = 1;

    private int currenthealth;
    private enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<enemy>();
    }
    private void OnEnable()
    {
        currenthealth = maxhitpoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        takedamage();
    }
    void takedamage()
    {
        currenthealth--;
        if (currenthealth <= 0)
        {
            _enemy.RewardGold();
            maxhitpoints += healthramp;
            gameObject.SetActive(false);
        }
        
    }   
}
