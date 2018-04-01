using System;
using System.Threading.Tasks;

namespace SmartPos.Desktop.Interfaces
{
    public enum ToolBarButtonLocation : short
    {
        Left = 0,
        Right = 1
    }

    public interface IToolBarButton
    {
        string Text { get; }
        Func<Task> Action { get; }
        ToolBarButtonLocation Location { get; }
    }
    
    public class ToolBarButton : IToolBarButton
    {
        #region Constructors

        public ToolBarButton(string text, Func<Task> action)
            : this(text, action, ToolBarButtonLocation.Left)
        {
        }

        public ToolBarButton(string text, Func<Task> action, ToolBarButtonLocation location)
        {
            Text = text;
            Action = action;
            Location = location;
        }
        
        #endregion

        #region Implementation of IToolBarButton

        /// <inheritdoc />
        public string Text { get; }

        /// <inheritdoc />
        public Func<Task> Action { get; }

        /// <inheritdoc />
        public ToolBarButtonLocation Location { get; }

        #endregion
    }
}