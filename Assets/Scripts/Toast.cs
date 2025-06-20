using DG.Tweening;
using TMPro;
using UnityEngine;

public class Toast : Popup
{
    [SerializeField] TextMeshProUGUI noti;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] CanvasGroup toastContent;

    bool isShow = false;


    public void ShowNoti(string content)
    {
        this.rectTransform.anchoredPosition = new Vector2(0, -600);

        DOTween.KillAll();
       // toastContent.alpha = 1;
        noti.text = content;
        isShow = true;

        Hide();
    }

    DG.Tweening.Sequence mySequence;
    public override void Hide()
    {
        mySequence = DOTween.Sequence();
        mySequence.Append(DOTweenModuleUI.DOAnchorPos(this.rectTransform, new Vector2(0f, 0f), 4.5f))
            .Insert(.2f, toastContent.DOFade(0.2f, 1.5f))
            .Insert(.1f, DOVirtual.DelayedCall(1.8f, () => { HidePopup(); }));
    }

    public void HidePopup()
    {
        base.Close();
        mySequence.Pause();
    }
}