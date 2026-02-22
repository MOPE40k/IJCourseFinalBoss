using System;
using DG.Tweening;
using Runtime.Ui.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.LevelMenuPopup
{
    public class LevelTileView : MonoBehaviour, IShowableView
    {
        // Delegates
        public event Action Clicked = null;

        [Header("References:")]
        [SerializeField] private Image _background = null;
        [SerializeField] private TMP_Text _levelNumberText = null;
        [SerializeField] private Button _button = null;

        [Space]
        [Header("Active Settings:")]
        [SerializeField] private Color _activeColor = Color.blue;
        [SerializeField] private Color _completedColor = Color.green;
        [SerializeField] private Color _blockedColor = Color.red;

        private void OnEnable()
            => _button.onClick.AddListener(OnClicked);

        private void OnDisable()
            => _button.onClick.RemoveListener(OnClicked);

        private void OnDestroy()
            => transform.DOKill();

        public void SetLevel(string text)
            => _levelNumberText.SetText(text);

        public void SetActive()
            => SetBackgroundColor(_activeColor);

        public void SetComplete()
            => SetBackgroundColor(_completedColor);

        public void SetBlock()
            => SetBackgroundColor(_blockedColor);

        public Tween Show()
        {
            transform.DOKill();

            return transform
                .DOScale(1f, 0.1f)
                .From(0f)
                .SetUpdate(true)
                .Play();
        }

        public Tween Hide()
        {
            transform.DOKill();

            return DOTween.Sequence();
        }

        private void OnClicked()
            => Clicked?.Invoke();

        private void SetBackgroundColor(Color color)
            => _background.color = color;
    }
}