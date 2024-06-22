// �����������

using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    // Slider UI�̎Q��
    public Slider slider;

    // �ő�l�ƌ��݂̒l
    public float maxValue = 100f;
    private float currentValue;

    // �t�B�[�o�[�^�C���̊Ǘ�
    bool fever = false;

    // �Q�[�W�̌������x
    public float decreaseRate = 10f;

    void Start()
    {
        // �Q�[�W�̏�����
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
            // �Q�[�W������������
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

    // �O������Ăяo���ăQ�[�W�𑝌�������֐�
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

    // �X���C�_�[�̒l���X�V����֐�
    void UpdateGauge()
    {
        slider.value = currentValue;
    }

    public void SetFever(bool value)
    {
        fever = value;
    }
}