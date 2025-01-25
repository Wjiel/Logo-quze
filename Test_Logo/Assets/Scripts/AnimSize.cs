using DG.Tweening;
using UnityEngine;

public class AnimSize : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector2.zero;
        transform.DOScale(1, 1).SetEase(Ease.OutBounce);
    }
}
