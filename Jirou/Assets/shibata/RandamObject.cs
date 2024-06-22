using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] blockPrefabs; // プレハブの配列
    public bool redy = true;
    public float interval = 1.0f;

    public int randomIndexNext;
    public int randomIndex;

    public GuzaiList guzaiList;
    void Start()
    {
        GameObject guzaiListObject = GameObject.Find("GameManager");
        if (guzaiListObject != null)
        {
            guzaiList = guzaiListObject.GetComponent<GuzaiList>();
        }

        randomIndexNext = Random.Range(0, blockPrefabs.Length);
        randomIndex = randomIndexNext;
        Debug.Log("first" + randomIndexNext);
    }



    // Update is called once per frame
    void Update()
    {
        if (redy)
        {
            StartCoroutine(MyCoroutine());
        }
    }

    //bool CheckAllBlockObjectsStopped()
    //{
    //    GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("Guzai"); // "Block" タグを持つオブジェクトを全て取得

    //    foreach (GameObject obj in blockObjects)
    //    {
    //        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
    //        if (rb != null && rb.velocity.magnitude >= 0.001f)
    //        {
    //            return false; // 条件を満たさないオブジェクトが見つかった場合、falseを返す
    //        }
    //    }

    //    return true; // 全てのオブジェクトが条件を満たす場合、trueを返す
    //}


    IEnumerator MyCoroutine()
    {
        redy = false;

        yield return new WaitForSeconds(interval);

        randomIndex = randomIndexNext;

        GameObject newObject = Instantiate(blockPrefabs[randomIndex], Vector2.zero, Quaternion.identity);

        randomIndexNext = Random.Range(0, blockPrefabs.Length);

        Debug.Log(randomIndexNext);

        guzaiList.generatedObjects.Add(newObject);

        


    }

}
