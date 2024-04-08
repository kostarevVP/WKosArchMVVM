using Lukomor;
using UnityEngine;

public class AboutUsWindowModel : WindowViewModel
{
    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
