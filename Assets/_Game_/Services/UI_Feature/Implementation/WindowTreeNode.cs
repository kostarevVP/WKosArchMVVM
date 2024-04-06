using Lukomor;
using System.Collections.Generic;

namespace WKosArch.Services.UIService.UI
{
    public class WindowTreeNode
    {
        public UiViewModel WindowViewModel { get; }
        public List<UiViewModel> WidgetViewModels { get; }
        public bool HasChild => WidgetViewModels.Count > 0;

        public WindowTreeNode(UiViewModel windowName)
        {
            WindowViewModel = windowName;
            WidgetViewModels = new List<UiViewModel>();
        }

        public void AddWidget(UiViewModel name)
        {
            WidgetViewModels.Add(name);
        }

        public UiViewModel RemoveLastWindget()
        {
            UiViewModel name = null;

            if (WidgetViewModels.Count > 0)
            {
                name = WidgetViewModels[WidgetViewModels.Count - 1];
                WidgetViewModels.RemoveAt(WidgetViewModels.Count - 1);
            }

            return name;
        }


    }
}