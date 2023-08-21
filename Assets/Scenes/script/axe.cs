using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    [SerializeField]
    [Tooltip("薪のプレハブを設定")]
    private GameObject woodPrefab;
    
    [SerializeField]
    [Tooltip("壊れた薪のプレハブを設定")]
    private GameObject brokenWoodPrefab; // 壊れた薪のプレハブ

    private GameObject woodObj;

    private float respawnTime = 0.5f;//再生成のインターバル
    // Start is called before the first frame update
    void Start()
    {
        
    }
     // プレハブから薪を生成する関数
    private void SpawnWood()
    {
        woodObj = Instantiate(woodPrefab);//プレハブに設定してあるものを生成
        woodObj.name = woodPrefab.name;
    }

    private IEnumerator OnCollisionEnter2D(Collision2D Collision){//斧が薪に当たった時の処理
        if(Collision.gameObject.name=="wood")//斧が薪に当たっとき
        {
        Vector3 woodPosition = Collision.transform.position;// 壊れた薪の位置に新しい薪を生成

        // オフセットを設定して新しい薪の位置を計算
        Vector3 newWoodPosition = woodPosition + new Vector3(-0.21f, -0.3f, 0f); // 調整

        Destroy(Collision.gameObject);
        GameObject newWood = Instantiate(brokenWoodPrefab, newWoodPosition, Quaternion.identity);

            GameManager GameManager = FindObjectOfType<GameManager>();
            if (GameManager != null)
            {
                GameManager.IncreaseWoodCount(); // 薪の数を増やす
            }

            yield return new WaitForSeconds(respawnTime);//respawnTIme待つ
                        
            Destroy(newWood);// 生成された新しい薪を削除
            SpawnWood();//生成
        }
    }
}
