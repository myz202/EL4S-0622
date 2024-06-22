using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSelector : MonoBehaviour
{
    public string targetTag = "Guzai"; // �I���������^�O��ݒ�

    public List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
        // �^�O�Ɉ�v����v���n�u������
        GameObject[] taggedPrefabs = GameObject.FindGameObjectsWithTag(targetTag);

        // ���X�g�ɒǉ�
        foreach (var prefab in taggedPrefabs)
        {
            prefabs.Add(prefab);
        }

        // �����_���ɑI��
        if (prefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("�v���n�u���Ȃ���[");
        }
    }
}
