using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOperater : MonoBehaviour
{
    GameObject[] Guzais;
    GameObject TopGuzai;
    float TopGuzaiPosy;
    GameObject BefforeGuzai;
    GameObject CurrentGuzai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Guzais = GameObject.FindGameObjectsWithTag("Guzai");
        foreach(GameObject gameObj in Guzais)
        {
            BefforeGuzai = TopGuzai;
            if(BefforeGuzai == null)
            {
                BefforeGuzai = gameObj;
            }
            CurrentGuzai = gameObj;

            TopGuzaiPosy = Mathf.Max(BefforeGuzai.transform.position.y, CurrentGuzai.transform.position.y);
            if(TopGuzaiPosy == BefforeGuzai.transform.position.y)
            {
                TopGuzai = BefforeGuzai;
            }
            else if(TopGuzaiPosy == CurrentGuzai.transform.position.y)
            {
                TopGuzai = CurrentGuzai;
            }
        }
        transform.position = new Vector3(transform.position.x, TopGuzai.transform.position.y, transform.position.z);
    }
}
