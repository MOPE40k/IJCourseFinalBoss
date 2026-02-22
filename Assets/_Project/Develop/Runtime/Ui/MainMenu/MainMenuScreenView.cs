using System;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OnLevelsMenuButtonClicked = null;

        [Header("References:")]
        [SerializeField] private IconTextListView _walletView = null;
        [SerializeField] private Button _openLevelsMenuButton = null;

        // Runtime
        public IconTextListView WalletView => _walletView;

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);

        }

        private void OnOpenLevelsMenuButtonClicked()
            => OnLevelsMenuButtonClicked?.Invoke();
    }
}