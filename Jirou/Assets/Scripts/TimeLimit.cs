using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField]public float timeLimit = 60.0f;
    private float time = 0;

    [SerializeField] string sceneName;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        time = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text.text = ("Žc‚è ") + time.ToString("F1");
        if(time <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
