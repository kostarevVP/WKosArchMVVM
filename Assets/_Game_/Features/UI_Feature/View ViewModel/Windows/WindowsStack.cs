using Lukomor;
using System.Collections.Generic;
using System.Linq;
using WKosArch.Services.UIService.UI;

namespace WKosArch.UIService.Views.Windows
{
    public class WindowsStack<TreeNode> where TreeNode : WindowTreeNode
    {
        public int Length => _windowsQueue.Count;

        private List<TreeNode> _windowsQueue;

        public WindowsStack()
        {
            _windowsQueue = new List<TreeNode>();
        }

        public void Push(TreeNode windowType)
        {
            bool queaAllreadyHasIHomeWIndow = Length == 1 && typeof(IHomeWindow).IsAssignableFrom(windowType.GetType());

            if (queaAllreadyHasIHomeWIndow)
                return;
            else
                _windowsQueue.Add(windowType);
        }

        public TreeNode Pop()
        {
            TreeNode result = null;

            if (_windowsQueue.Any())
            {
                var lastIndex = _windowsQueue.Count - 1;

                result = _windowsQueue[lastIndex];

                //if (!typeof(IHomeWindow).IsAssignableFrom(result.WindowViewModel.GetType()))
                    _windowsQueue.RemoveAt(lastIndex);
            }

            return result;
        }

        public void Clear()
        {
            _windowsQueue.Clear();
        }

        public void RemoveLast(TreeNode type)
        {
            if (_windowsQueue.Contains(type))
            {
                var lastIndexOf = _windowsQueue.LastIndexOf(type);

                _windowsQueue.RemoveAt(lastIndexOf);
            }
        }

        public TreeNode GetLast()
        {
            return _windowsQueue.Last();
        }

        internal void Remove(TreeNode windowType)
        {
            _windowsQueue.Remove(windowType);
        }
    }
}