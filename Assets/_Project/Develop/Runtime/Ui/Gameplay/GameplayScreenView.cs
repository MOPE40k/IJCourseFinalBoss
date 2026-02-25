using System;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Ui.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        // Delegates
        public event Action SendButtonClicked = null;

        [Header("References:")]
        [SerializeField] private TextView _sequenceText = null;
        [SerializeField] private TextView _inputText = null;
        [SerializeField] private Button _sendButton = null;

        // Runtime
        public TextView SequenceText => _sequenceText;
        public TextView InputText => _inputText;

        private void OnEnable()
            => Subscribe();

        private void OnDisable()
            => Unsubscribe();

        public void Subscribe()
            => _sendButton.onClick.AddListener(OnSendButtonClicked);

        public void Unsubscribe()
            => _sendButton.onClick.RemoveListener(OnSendButtonClicked);

        private void OnSendButtonClicked()
            => SendButtonClicked?.Invoke();
    }
}