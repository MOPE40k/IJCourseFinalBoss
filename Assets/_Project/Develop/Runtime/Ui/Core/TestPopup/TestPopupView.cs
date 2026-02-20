using TMPro;
using UnityEngine;

namespace Runtime.Ui.Core.TestPopup
{
    public class TestPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text = null;

        public void SetText(string text)
            => _text.SetText(text);
    }
}