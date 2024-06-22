using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField]public float timeLimit = 60.0f;
    private float waitTime = 10f;
    private float time = 0;

    [SerializeField] string sceneName;
    public Text text;

    public AudioSource startSE;
    public AudioSource finishSE;

    public GameObject kaishi;
    public GameObject sokomade;

    // Start is called before the first frame update
    void Start()
    {
        time = timeLimit;
        waitTime = 10f;
        kaishi.SetActive(false);
        sokomade.SetActive(false);
        StartCoroutine(WaitStart());
    }

    private IEnumerator WaitStart()
    {
        while(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            text.text = ("開始まで ") + waitTime.ToString("F1");
            yield return null;
        }
        //startSE.Play();
        kaishi.SetActive(true);
        yield return new WaitForSeconds(1f);
        kaishi.SetActive(false);
        StartCoroutine(Countdown());

    }

    private IEnumerator Countdown()
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            text.text = ("残り ") + time.ToString("F1");
            yield return null;
        }
        // 制限時間が0になったらSEを再生し、画像を表示
        //finishSE.Play();
        sokomade.SetActive(true);

        // 2秒間待機
        yield return new WaitForSeconds(2f);

        // リザルトシーンをロード
        SceneManager.LoadScene(sceneName);
    }
}
