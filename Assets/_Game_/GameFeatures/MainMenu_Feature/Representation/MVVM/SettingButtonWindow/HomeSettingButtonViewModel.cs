using Lukomor.MVVM;
using WKosArch.UIService.Views.Windows;

public class HomeSettingButtonViewModel : WindowViewModel, IHomeWindow
{
    protected override void AwakeInternal()
    {
        base.AwakeInternal();
        //var settingViewModel = new SettingViewModel(DiContainer, 1f);
        //var view = GetComponent<View>();
        //view.Bind(settingViewModel);
        //settingViewModel.OpenSettingMenuWindow();
    }

    internal void OpenMainMenu()
    {
        //UI.Show<MainMenuWindowModel>();
    }

    internal void OpenQuestWindow() 
    {
        //UI.Show<QuestWindowModel>();
    }
}
