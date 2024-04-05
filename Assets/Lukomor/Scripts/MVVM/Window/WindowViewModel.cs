namespace Lukomor
{
    public abstract class WindowViewModel : UiViewModel
    {
        public void Back() => 
            UI.Back();

        public void CloseAllWindow() => 
            UI.CloseAllWindowInStack();
    }
}
