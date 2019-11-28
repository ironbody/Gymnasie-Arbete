using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyTween : MonoBehaviour
{

    public float duration;

    public void MoveToPosition(Vector2 position)
    {
        StartCoroutine(MoveEnumerator(position));
    }

    IEnumerator MoveEnumerator(Vector2 position)
    {
        Tween moveTween = transform.DOMove(position, duration, false);
        yield return moveTween.WaitForCompletion();
    }
}