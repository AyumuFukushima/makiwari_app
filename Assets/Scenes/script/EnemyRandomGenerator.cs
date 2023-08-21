using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;    // 生成オブジェクト
    [SerializeField] int generateFrame = 1000;        // 生成する間隔

    int frame = 0;
    int spawnFlg = 0;

    void Update()
    {
        ++frame;
        spawnFlg = Random.Range(0, 2);

        if (frame > generateFrame && spawnFlg == 1)
        {
            int index = Random.Range(0, enemyList.Count);

            Instantiate(enemyList[index], new Vector3(-11, -4, 0), Quaternion.identity);
            frame = 0;
        }
    }
}