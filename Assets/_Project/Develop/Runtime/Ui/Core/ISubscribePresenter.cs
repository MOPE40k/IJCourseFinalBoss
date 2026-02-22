namespace Runtime.Ui.Core
{
    public interface ISubscribePresenter : IPresenter
    {
        void Subscribe();

        void Unsubscribe();
    }
}