/*
 *  �q�X�N���v�g
 *  Abe.K
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_Guest : MonoBehaviour
{
    /// <summary> �J�n�ҋ@����  </summary>
    [SerializeField] [Header("�J�n�ҋ@����")] private float _startStandbyTime;

    /// <summary> �ʏ�ҋ@����  </summary>
    [SerializeField] [Header("�ʏ�ҋ@����")] private float _standbyTime;

    /// <summary> �t�B�[�o�[���ҋ@����  </summary>
    [SerializeField] [Header("�t�B�[�o�[���ҋ@����")] private float _feverStandbyTime;

    /// <summary> �J�n�ҋ@�I���t���O </summary>
    private bool _standby;

    private void Start()
    {
        _standby = false;
        StartCoroutine(StartStandby());
    }


    private void FixedUpdate()
    {
        if (!_standby)//�X�^���o�C�O�͏������Ȃ�
        {
            return;
        }

        EatProc();
    }

    /// <summary>
    /// �H�ׂ鏈��
    /// </summary>
    private void EatProc()
    {
        List<GameObject> foodList = new List<GameObject>();

        //=================//
        //�H�ו��R���e�i�m��
        //================//
        if(foodList.Count <= 0)
        {
            return;
        }

        GameObject bottomObj;
        int num = 0;
        bottomObj = foodList[num];

        for(int i = 1; i < foodList.Count; i++)
        {
            if (foodList[i].transform.position.y < bottomObj.transform.position.y)
            {
                bottomObj = foodList[i];
                num = i;
            }
        }

        //===============
        // �H�ו��̃��\�b�h�Ăяo��
        // 
        //===============

        foodList.RemoveAt(num);//�H�ׂ�ꂽ�v�f�폜

        _standby = false;//�X�^���o�C�t���O�𗎂Ƃ�
        StartCoroutine(Standby());//�X�^���o�C�R���[�`��
    }


    /// <summary>
    /// �X�^�[�g�X�^���o�C�R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartStandby()
    {
        float elapsedTime = 0.0f; // �o�ߎ���
        while (elapsedTime < _startStandbyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _standby = true;
    }


    /// <summary>
    /// �X�^���o�C�R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator Standby()
    {
        float elapsedTime = 0.0f; // �o�ߎ���

        //if(){} //�t�B�[�o�[
        //else{} //�ʏ�

        while (elapsedTime < _standbyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _standby = true;
    }

}
