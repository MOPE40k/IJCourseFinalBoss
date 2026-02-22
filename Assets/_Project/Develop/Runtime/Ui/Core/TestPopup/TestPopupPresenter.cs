using Utils.CoroutinesManagement;

namespace Runtime.Ui.Core.TestPopup
{
    public class TestPopupPresenter : PopupPresenterBase
    {
        private readonly TestPopupView _view = null;

        public TestPopupPresenter(
            TestPopupView view,
            ICoroutinePerformer coroutinePerformer)
            : base(coroutinePerformer)
        {
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Init()
        {
            base.Init();

            _view.SetText("TEST TITLE");
        }
    }
}