using System;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OnTestPopupButtonClicked = null;

        [Header("References:")]
        [SerializeField] private IconTextListView _walletView = null;
        [SerializeField] private Button _openTestPopupButton = null;

        // Runtime
        public IconTextListView WalletView => _walletView;

        private void OnEnable()
        {
            _openTestPopupButton.onClick.AddListener(OnOpenTestPopupButtonClicked);
        }

        private void OnDisable()
        {
            _openTestPopupButton.onClick.RemoveListener(OnOpenTestPopupButtonClicked);

        }

        private void OnOpenTestPopupButtonClicked()
            => OnTestPopupButtonClicked?.Invoke();
    }
}