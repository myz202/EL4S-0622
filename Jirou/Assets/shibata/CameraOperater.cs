using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOperater : MonoBehaviour
{
    GameObject highestObject;

    public GameObject guzaiListObject; // GuzaiList �X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g
    private GuzaiList guzaiList;

    float DefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (guzaiListObject != null)
        {
            guzaiList = guzaiListObject.GetComponent<GuzaiList>();
        }

        DefaultPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (guzaiList != null && guzaiList.generatedObjects != null && guzaiList.generatedObjects.Count > 0)
        {
            // ���X�g����null�`�F�b�N
            highestObject = null;
            foreach (GameObject obj in guzaiList.generatedObjects)
            {
                if (obj != null)
                {
                    if (highestObject == null || obj.transform.position.y > highestObject.transform.position.y)
                    {
                        highestObject = obj;
                    }
                }
            }


            // ���g�̃I�u�W�F�N�g��highestObject��Y���W�Ɉړ�
            //transform.position = new Vector3(transform.position.x, highestObject.transform.position.y, transform.position.z);

            transform.position = new Vector3(0, highestObject.transform.position.y + 1, transform.position.z);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("X = " + highestObject.transform.position.x);
            Debug.Log("Y = " + highestObject.transform.position.y);
            Debug.Log("Z = " + highestObject.transform.position.z);
        }
    }
}

