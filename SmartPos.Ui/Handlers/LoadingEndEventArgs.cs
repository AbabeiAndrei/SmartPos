using System;

namespace SmartPos.Ui.Handlers
{
    public delegate void LoadingEndEventHandler(object sender, LoadingEndEventArgs e);

    public class LoadingEndEventArgs : EventArgs
    {
        #region Properties

        public bool FromTimeOut { get; }

        public new static LoadingEndEventArgs Empty => new LoadingEndEventArgs(false);

        #endregion

        #region Constructors

        public LoadingEndEventArgs(bool fromTimeOut)
        {
            FromTimeOut = fromTimeOut;
        }

        #endregion
    }
}
