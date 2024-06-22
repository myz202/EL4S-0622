using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] blockPrefabs; // �v���n�u�̔z��
    public bool redy = true;


    void Start()
    {
        // �����_���ȃC���f�b�N�X��I��


        //int randomIndex = Random.Range(0, blockPrefabs.Length);

        // �v���n�u�𐶐�����(0,0)�ɔz�u
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
        GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("Guzai"); // "Block" �^�O�����I�u�W�F�N�g��S�Ď擾

        foreach (GameObject obj in blockObjects)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.magnitude >= 0.001f)
            {
                return false; // �����𖞂����Ȃ��I�u�W�F�N�g�����������ꍇ�Afalse��Ԃ�
            }
        }

        return true; // �S�ẴI�u�W�F�N�g�������𖞂����ꍇ�Atrue��Ԃ�
    }
}
