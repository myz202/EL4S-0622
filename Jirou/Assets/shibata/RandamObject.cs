using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] blockPrefabs; // プレハブの配列
    public bool redy = true;


    void Start()
    {
        // ランダムなインデックスを選択


        //int randomIndex = Random.Range(0, blockPrefabs.Length);

        // プレハブを生成して(0,0)に配置
        //Instantiate(blockPrefabs[randomIndex], Vector2.zero, Quaternion.identity);

    }



    // Update is called once per frame
    void Update()
    {
        if (redy)
        {
            //Debug.Log(CheckAllBlockObjectsStopped());

            int randomIndex = Random.Range(0, blockPrefabs.Length);

            Instantiate(blockPrefabs[randomIndex], Vector2.zero, Quaternion.identity);
            redy = false;
        }


    }

    bool CheckAllBlockObjectsStopped()
    {
        GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("Guzai"); // "Block" タグを持つオブジェクトを全て取得

        foreach (GameObject obj in blockObjects)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.magnitude >= 0.001f)
            {
                return false; // 条件を満たさないオブジェクトが見つかった場合、falseを返す
            }
        }

        return true; // 全てのオブジェクトが条件を満たす場合、trueを返す
    }
}
