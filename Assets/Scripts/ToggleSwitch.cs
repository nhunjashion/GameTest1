using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{
    public bool CurrentValue; //{ get; private set; }
    private bool _previousValue;
    [SerializeField] private Slider _slider;

    [Header("Animation")]
    [SerializeField, Range(0, 1f)] private float animationDuration = 0.5f;

    private Coroutine _animateSliderCoroutine;

    public event Action<SettingType,bool> OnToggle;
    [SerializeField] private SettingType _settingType;

    protected Action transitionEffect;

    public void SetupSliderComponent(int value)
    {

        if (_slider == null)
        {
            Debug.Log("No slider found!", this);
            return;
        }
        _slider.interactable = false;
        _slider.value = value;
        CurrentValue = value == 1;
        Debug.Log("value: " + _slider.value);

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }


    private void Toggle()
    {
        SetStateAndStartAnimation(!CurrentValue);
    }


    private void SetStateAndStartAnimation(bool state)
    {
        _previousValue = CurrentValue;
        CurrentValue = state;

        OnToggle?.Invoke(this._settingType,CurrentValue);

        if (_animateSliderCoroutine != null)
            StopCoroutine(_animateSliderCoroutine);

        _animateSliderCoroutine = StartCoroutine(AnimateSlider());
    }


    private IEnumerator AnimateSlider()
    {
        float endValue = CurrentValue ? 1 : 0;

        if (animationDuration > 0)
            _slider.DOValue(endValue, animationDuration);
        else 
            _slider.value = endValue;

        yield return null;
    }
}
