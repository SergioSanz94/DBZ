using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1GeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float generatorTimer = 6f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fast", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEnemy1()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    public void StartGenerator1()
    {
        InvokeRepeating("CreateEnemy1", 0f, generatorTimer);
    }
    public void CancelGenerator1()
    {
        CancelInvoke("CreateEnemy1");
    }
    void Fast()
    {
        generatorTimer = generatorTimer - 0.5f;
    }
}
