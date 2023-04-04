using UnityEngine;

public class tower : MonoBehaviour
{
    [Range(0, 100)][SerializeField]private int cost = 75;
    
    // Fabric -> is wathcing for creating objects
    public bool spawntower(tower tower, Vector3 position)
    {
        var _bank = FindObjectOfType<bank>();
        if (_bank == null)
            return false;
        if (_bank.currbalance < cost)
            return false;

        Instantiate(tower.gameObject, position, Quaternion.identity);
        _bank.withdraw(cost);
        return true;
    }
}
