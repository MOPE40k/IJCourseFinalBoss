namespace Utils.LoadingScreen
{
    public interface ILoadingScreen : IService
    {
        // Runtime
        bool IsShow { get; }

        void Show();

        void Hide();
    }
}