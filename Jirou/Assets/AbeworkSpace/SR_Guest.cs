/*
 *  客スクリプト
 *  Abe.K
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_Guest : MonoBehaviour
{
    [SerializeField] [Header("Feverスクリプト")] private GaugeManager sr_gm;

    /// <summary> 開始待機時間  </summary>
    [SerializeField] [Header("開始待機時間")] private float startStandbyTime;

    /// <summary> 通常待機時間  </summary>
    [SerializeField] [Header("通常待機時間")] private float standbyTime;

    /// <summary> フィーバー時待機時間  </summary>
    [SerializeField] [Header("フィーバー時待機時間")] private float feverStandbyTime;

    /// <summary> 開始待機終了フラグ </summary>
    private bool standby;

    private void Start()
    {
        standby = false;
        StartCoroutine(StartStandby());
    }


    private void FixedUpdate()
    {
        if (!standby)//スタンバイ前は処理しない
        {
            return;
        }

        EatProc();
    }

    /// <summary>
    /// 食べる処理
    /// </summary>
    private void EatProc()
    {
        GameObject obj = FindAnyObjectByType<GuzaiList>().gameObject;
        GuzaiList gl = obj.GetComponent<GuzaiList>();

        if(gl.generatedObjects.Count <= 0)
        {
            return;
        }

        GameObject bottomObj;
        int num = 0;
        bottomObj = gl.generatedObjects[num];

        for(int i = 1; i < gl.generatedObjects.Count; i++)
        {
            if (gl.generatedObjects[i].transform.position.y < bottomObj.transform.position.y)
            {
                bottomObj = gl.generatedObjects[i];
                num = i;
            }
        }

        //===============
        // 食べ物のメソッド呼び出し
        // 
        //===============

        gl.generatedObjects[num].GetComponent<Block>().EatProc();
        gl.DeleteList(num);//食べられた要素削除

        standby = false;//スタンバイフラグを落とす
        StartCoroutine(Standby());//スタンバイコルーチン
    }


    /// <summary>
    /// スタートスタンバイコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartStandby()
    {
        float elapsedTime = 0.0f; // 経過時間
        while (elapsedTime < startStandbyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        standby = true;
    }


    /// <summary>
    /// スタンバイコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator Standby()
    {
        float elapsedTime = 0.0f; // 経過時間
        float limitTime = 0.0f;

        if (sr_gm.GetFever()) { limitTime = feverStandbyTime; }
        else { limitTime = standbyTime; }
       

        while (elapsedTime < limitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        standby = true;
    }

}
