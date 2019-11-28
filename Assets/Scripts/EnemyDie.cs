using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        Debug.Log("Executed Die Script");
        transform.parent.GetComponent<EnemyMove>().RemoveEnemy(this.gameObject);
        GameHandler.EnemyKilled();
        Destroy(this.gameObject);

    }
}