using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runtime.Ui.Core.TestPopup
{
    public class TestPopupPresenter : PopupPresenterBase
    {
        private readonly TestPopupView _view = null;

        public TestPopupPresenter(TestPopupView view)
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