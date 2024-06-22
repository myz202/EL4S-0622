using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image FadePanel;
    public float FadeDuration = 1.0f;
    private string NextScene;
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(string nextscene)
    {
        NextScene = nextscene;
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        FadePanel.enabled = true;
        float ErapsedTime = 0.0f;
        Color StartColor = FadePanel.color;
        Color EndColor = new Color(StartColor.r, StartColor.g, StartColor.b, 1.0f);

        while (ErapsedTime < FadeDuration)
        {
            ErapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(ErapsedTime / FadeDuration);
            FadePanel.color = Color.Lerp(StartColor, EndColor, t);
            yield return null;
        }

        FadePanel.color = EndColor;
        SceneManager.LoadScene(NextScene);
    }
}

