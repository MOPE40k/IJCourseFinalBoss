using DG.Tweening;

namespace Runtime.Ui.Core
{
    public interface IShowableView : IView
    {
        Tween Show();

        Tween Hide();
    }
}