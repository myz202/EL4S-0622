using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextGuzaiSprite : MonoBehaviour
{
    public Image targetImage; // �ύX�Ώۂ�Image�R���|�[�l���g
    public List<Sprite> sprites;
    int nextIndex;
    RandamObject randObj;

    void Start()
    {

        GameObject guzaiObject = GameObject.Find("GameManager");
        if (guzaiObject != null)
        {
            randObj = guzaiObject.GetComponent<RandamObject>();
        }
    }

    private void Update()
    {

        nextIndex = randObj.randomIndexNext;

        if (targetImage != null && sprites != null)
        {
            // Image�R���|�[�l���g��sprite��V�������̂ɕύX
            targetImage.sprite = sprites[nextIndex];
        }
        else
        {
            Debug.LogError("Target Image or New Sprite is not assigned.");
        }
    }

}
