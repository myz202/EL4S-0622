// たかぎあゆむ

using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    // Slider UIの参照
    public Slider slider;

    // 最大値と現在の値
    public float maxValue = 100f;
    private float currentValue;

    // フィーバータイムの管理
    bool fever = false;

    // ゲージの減少速度
    public float decreaseRate = 10f;

    void Start()
    {
        // ゲージの初期化
        slider.maxValue = maxValue;
        currentValue = 0;
        UpdateGauge();
    }

    void Update()
    {
        if(currentValue== maxValue)
        {
            fever = true;
        }

        if (fever)
        {
            // ゲージを減少させる
            if (currentValue > 0)
            {
                currentValue -= decreaseRate * Time.deltaTime;
                if (currentValue < 0)
                {
                    currentValue = 0;
                    fever = false;
                }
                UpdateGauge();
            }
        }
    }

    // 外部から呼び出してゲージを増減させる関数
    public void ModifyGauge(float amount)
    {
        currentValue += amount;
        if (currentValue > maxValue)
        {
            currentValue = maxValue;
            fever = true;
        }
        else if (currentValue < 0)
        {
            currentValue = 0;
        }
        UpdateGauge();
    }

    // スライダーの値を更新する関数
    void UpdateGauge()
    {
        slider.value = currentValue;
    }

    public void SetFever(bool value)
    {
        fever = value;
    }
}
