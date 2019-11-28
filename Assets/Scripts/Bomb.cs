using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoIt());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoIt()
    {
        Tween moveTween = transform.DOMoveY(transform.position.y - 10, 2.5f, false);

        yield return moveTween.WaitForCompletion();

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}