using Runtime.Meta.Features.Stats;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.Core;
using UnityEngine.UI;
using Utils.CoroutinesManagement;

namespace Runtime.Ui.ResetStatsPopup
{
    public class ResetStatsPopupPresenter : PopupPresenterBase
    {
        // Const
        private const string GoldEnoughText = "Reset";
        private const string GoldNotEnoughText = "Not enough gold!";

        // References
        private readonly ResetStatsPopupView _view = null;
        private readonly ResetStatsService _resetStatsService = null;
        private readonly Button _resetButton = null;

        public ResetStatsPopupPresenter(
            ResetStatsPopupView view,
            ResetStatsService resetStatsService,
            ICoroutinePerformer coroutinePerformer) : base(coroutinePerformer)
        {
            _view = view;
            _resetStatsService = resetStatsService;
            _resetButton = _view.ResetButton;
        }

        // Runtime
        protected override PopupViewBase PopupView => _view;

        public override void Init()
        {
            base.Init();

            if (_resetStatsService.IsEnough(CurrencyTypes.Gold))
            {
                _view.ResetButtonClicked += OnResetButtonClicked;

                _view.SetTitle(GoldEnoughText);

                _resetButton.interactable = true;
            }
            else
            {
                _view.SetTitle(GoldNotEnoughText);

                _resetButton.interactable = false;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ResetButtonClicked -= OnResetButtonClicked;
        }

        private void OnResetButtonClicked()
        {
            _resetStatsService.ResetStats();

            _view.OnCloseButtonClicked();
        }
    }
}