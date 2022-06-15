namespace UI.Menu
{
    public interface IPanel
    {
        public EPanelType Type { get; }

        public void Init();
        public void Show();
        public void Hide();
    }
}