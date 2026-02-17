namespace Utils.LoadingScreen
{
    public interface ILoadingScreen
    {
        // Runtime
        bool IsShow { get; }

        void Show();

        void Hide();
    }
}