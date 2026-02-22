using Runtime.Ui.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.CommonViews
{
    public class IconTextView : MonoBehaviour, IView
    {
        [Header("References:")]
        [SerializeField] private TMP_Text _text = null;
        [SerializeField] private Image _icon = null;

        public void SetText(string text)
            => _text.SetText(text);

        public void SetIcon(Sprite icon)
            => _icon.sprite = icon;
    }
}