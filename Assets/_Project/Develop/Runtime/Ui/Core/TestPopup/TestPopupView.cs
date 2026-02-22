using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Runtime.Ui.Core.TestPopup
{
    public class TestPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text = null;

        public void SetText(string text)
            => _text.SetText(text);

        protected override void ModifyShowAnimation(Sequence tweenSequence)
        {
            base.ModifyShowAnimation(tweenSequence);

            tweenSequence
                .Append(_text
                    .DOFade(1f, 0.2f)
                    .From(0f));
        }
    }
}