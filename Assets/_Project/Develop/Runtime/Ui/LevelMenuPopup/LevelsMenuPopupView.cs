using UnityEngine;
using Runtime.Ui.Core;
using TMPro;
using DG.Tweening;

namespace Runtime.Ui.LevelMenuPopup
{
    public class LevelsMenuPopupView : PopupViewBase
    {
        [Header("Refernces:")]
        [SerializeField] private TMP_Text _title = null;
        [SerializeField] private LevelTilesListView _levelTilesListView = null;

        // Runtime
        public LevelTilesListView LevelTilesListView => _levelTilesListView;

        public void SetTitle(string text)
            => _title.SetText(text);

        protected override void ModifyShowAnimation(Sequence tweenSequence)
        {
            base.ModifyShowAnimation(tweenSequence);

            foreach (LevelTileView view in _levelTilesListView.Elements)
                tweenSequence
                    .Append(view.Show())
                    .AppendInterval(0.2f);
        }
    }
}