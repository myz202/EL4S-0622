using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;

public class SR_SoundTest : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SR_SoundManager.instance.PlaySE(SE_Type.GUEST_STANDBY);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SR_SoundManager.instance.PlaySE(SE_Type.DELICIOUS);
        }
    }
}
