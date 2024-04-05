using Lukomor;

public class MainMenuViewModel : WindowViewModel
{
    public void OpenAboutUs()
    {
        UI.Show<AboutUsWindowModel>();
    }
}
