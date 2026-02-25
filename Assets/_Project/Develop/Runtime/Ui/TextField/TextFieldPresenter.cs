using System;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using Utils.Reactive;

namespace Runtime.Ui.TextField
{
    public class TextFieldPresenter : IPresenter
    {
        // References
        private readonly IReadOnlyVeriable<string> _text = null;
        private readonly TextView _view = null;

        // Runtime
        public TextView View => _view;
        private IDisposable _disposable = null;

        public TextFieldPresenter(
            IReadOnlyVeriable<string> text,
            TextView view)
        {
            _text = text;
            _view = view;
        }

        public void Init()
        {
            UpdateValue(_text.Value);

            _disposable = _text.Subscribe(OnValueChanged);
        }

        public void Dispose()
            => _disposable.Dispose();

        private void OnValueChanged(string oldValue, string newValue)
            => UpdateValue(newValue);

        private void UpdateValue(string newValue)
            => _view.SetText(newValue);
    }
}