using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Desktop.Interfaces
{
    public interface IToolBarCustomizer
    {
        bool ShowLogout { get; }
        bool ShowOptions { get; }
        IEnumerable<IToolBarButton> Buttons { get; }
    }

    class DefaultToolBarCustomizer : IToolBarCustomizer
    {
        #region Implementation of IToolBarCustomizer

        /// <inheritdoc />
        public bool ShowLogout => true;

        /// <inheritdoc />
        public bool ShowOptions => true;

        /// <inheritdoc />
        public IEnumerable<IToolBarButton> Buttons => null;

        #endregion
    }
}
