
using UnityEngine;

public abstract class Popup : MonoBehaviour
{
    [SerializeField] GameObject content;
    public virtual void Open()
    {
        transform.SetAsLastSibling();
        content.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        content.SetActive(false);
        // SoundManager.Instance.PlaySound(SoundName.UI_Button_Click, GameConstants.UI_BTN_CLICK_VOLUMNE);

    }

    public virtual void Animate()
    {

    }

    public virtual void Hide() 
    { 
    }

}
