using DG.Tweening;
using UnityEngine;

public class letteranim : MonoBehaviour
{
    [SerializeField] private float moveposx;
    [SerializeField] private float moveposy;
    [SerializeField] private int duration = 1;

    private void Start()
    {
        transform.DOMove(new Vector2(moveposx, moveposy), duration: duration);
    }

}
