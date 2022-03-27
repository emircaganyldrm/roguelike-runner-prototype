using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerScript : MonoBehaviour
{
    public float spawnDistance = 50f;
    public Transform player;
    public levelManager _levelManager;

    [Header("Objects To Spawn")] 
    public List<GameObject> objectList;
    public GameObject Boss;
    public GameObject UpgradePanel;
    
    [Header("Timers")] 
    public float enemyTimer = 5;
    public float panelTimer = 12f;
    public float bossTimer = 55f;



    private void Start()
    {
        StartCoroutine(SpawnEnemyEnum());
        StartCoroutine(SpawnBoss());
    }

    private void Update()
    {
        if (enemyTimer > 1)
        {
            enemyTimer -= 0.01f * Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        float[] xArray = {-2, 0, 2};
        int RandomX = Random.Range(0, 3);
        float xValue = xArray[RandomX];
        Vector3 _spawnPos = new Vector3(xValue, 1, player.position.z + spawnDistance);
        var enemy = Instantiate(objectToSpawn(), _spawnPos, Quaternion.identity);

        //Changing health values
        enemy.GetComponent<HealthSystem>().IncreaseMaxHealth(_levelManager.level * 100);
    }

    GameObject objectToSpawn()
    {
        switch (_levelManager.level)
        {
            case < 10:
                return objectList[0];
            case > 10:
                return objectList[1];
        }
        return objectList[1];
    }

    private IEnumerator SpawnEnemyEnum()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemyTimer);
        }
    }
    
    /*private IEnumerator SpawnPanel()
    {
        while (true)
        {
            yield return new WaitForSeconds(panelTimer);
        }
    }*/
    
    public void SpawnPanel()
    {
        Instantiate(UpgradePanel, Vector3.forward * (player.position.z + 50f), Quaternion.identity);
    }

    private IEnumerator SpawnBoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(bossTimer);
            var boss = Instantiate(Boss, new Vector3(0,5,(player.position.z + 50f)), Quaternion.identity);

            //Changing health values
            boss.GetComponent<HealthSystem>().IncreaseMaxHealth(_levelManager.level * 50);
        }
    }
}
