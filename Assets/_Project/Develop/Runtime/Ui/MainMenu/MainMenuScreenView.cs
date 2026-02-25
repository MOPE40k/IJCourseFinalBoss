using System;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        // Delegates
        public event Action LettersModeButtonClicked = null;
        public event Action DigitsModeButtonClicked = null;
        public event Action ResetStatsButtonClicked = null;

        [Header("References:")]
        [SerializeField] private IconTextListView _walletView = null;
        [SerializeField] private IconTextListView _sessionResultsView = null;
        [SerializeField] private Button _lettersModeButton = null;
        [SerializeField] private Button _digitsModeButton = null;
        [SerializeField] private Button _resetStatsButton = null;

        // Runtime
        public IconTextListView WalletView => _walletView;
        public IconTextListView SessionsResultsView => _sessionResultsView;

        private void OnEnable()
            => Subscribe();

        private void OnDisable()
            => Unsubscribe();

        private void Subscribe()
        {
            _digitsModeButton.onClick.AddListener(OnDigitsModeButtonClicked);
            _lettersModeButton.onClick.AddListener(OnLettersModeButtonClicked);
            _resetStatsButton.onClick.AddListener(OnResetStatsButtonClicked);
        }

        private void Unsubscribe()
        {
            _digitsModeButton.onClick.RemoveListener(OnDigitsModeButtonClicked);
            _lettersModeButton.onClick.RemoveListener(OnLettersModeButtonClicked);
            _resetStatsButton.onClick.RemoveListener(OnResetStatsButtonClicked);
        }

        private void OnLettersModeButtonClicked()
            => LettersModeButtonClicked?.Invoke();

        private void OnDigitsModeButtonClicked()
            => DigitsModeButtonClicked?.Invoke();

        private void OnResetStatsButtonClicked()
            => ResetStatsButtonClicked?.Invoke();
    }
}