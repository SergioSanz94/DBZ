using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2GeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float generatorTimer = 9f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateEnemy2()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    public void StartGenerator2()
    {
        InvokeRepeating("CreateEnemy2", 0f, generatorTimer);
    }
    public void CancelGenerator2()
    {
        CancelInvoke("CreateEnemy2");
    }
    

}
