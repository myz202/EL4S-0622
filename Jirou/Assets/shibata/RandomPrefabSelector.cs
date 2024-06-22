using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSelector : MonoBehaviour
{
    public string targetTag = "Guzai"; // 選択したいタグを設定

    public List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
        // タグに一致するプレハブを検索
        GameObject[] taggedPrefabs = GameObject.FindGameObjectsWithTag(targetTag);

        // リストに追加
        foreach (var prefab in taggedPrefabs)
        {
            prefabs.Add(prefab);
        }

        // ランダムに選択
        if (prefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("プレハブがないよー");
        }
    }
}
