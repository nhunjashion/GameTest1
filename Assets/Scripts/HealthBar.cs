using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider easeHpSlider;
    [SerializeField] Slider mpSlider;
    [SerializeField] float duration = .1f;
    [SerializeField] float easeDuration = .5f;
    [SerializeField] float hp = 100;
    [SerializeField] float mp = 200;

    private void Start()
    {
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
        easeHpSlider.maxValue = hp;
        easeHpSlider.value = hp;
        mpSlider.maxValue = mp;
        mpSlider.value = mp;

    }
    public void UpdateHeattValue(float value)
    {
        hpSlider.DOValue(value, .1f);
        easeHpSlider.DOValue(value, easeDuration);
    }

    public void UpdateManaValue(float value)
    {
        mpSlider.DOValue(value, easeDuration);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hp -= 10;
            UpdateHeattValue(hp);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            hp -= 20;
            mp += 20;
            UpdateHeattValue(hp);
            UpdateManaValue(mp);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            hp += 30;
            mp -= 50;
            UpdateHeattValue(hp);
            UpdateManaValue(mp);
        }

    }
}
