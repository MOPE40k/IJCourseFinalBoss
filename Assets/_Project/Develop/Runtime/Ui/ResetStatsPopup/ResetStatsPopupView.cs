using UnityEngine;
using TMPro;
using Runtime.Ui.Core;
using UnityEngine.UI;
using System;

namespace Runtime.Ui.ResetStatsPopup
{
    public class ResetStatsPopupView : PopupViewBase
    {
        // Delegates
        public event Action ResetButtonClicked = null;

        [Header("References:")]
        [SerializeField] private TMP_Text _title = null;
        [SerializeField] private Button _resetButton = null;

        // Runtime
        public Button ResetButton => _resetButton;

        private void OnEnable()
            => _resetButton.onClick.AddListener(OnResetButtonClicked);

        private void OnDisable()
            => _resetButton.onClick.RemoveListener(OnResetButtonClicked);

        public void SetTitle(string text)
            => _title.SetText(text);

        private void OnResetButtonClicked()
            => ResetButtonClicked?.Invoke();
    }
}