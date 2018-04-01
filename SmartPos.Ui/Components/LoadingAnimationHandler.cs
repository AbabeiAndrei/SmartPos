using System;

namespace SmartPos.Ui.Components
{
    public class LoadingAnimationHandler : ILoadingToken
    {
        #region Fields

        private readonly BaseForm _form;
        private bool _loading;

        #endregion

        #region Properties

        public bool Loading
        {
            get => _loading;
            set
            {
                if (!_loading && value)
                    StartLoading();
                else if (_loading && !value)
                    StopLoading();

                _loading = value;
            }
        }

        public int TimeOut { get; set; }

        #endregion

        #region Constructors

        public LoadingAnimationHandler(BaseForm form)
        {
            _form = form;
        }

        #endregion

        #region Protected methods

        protected virtual void StartLoading()
        {
            if (_form.InvokeRequired)
                _form.Invoke(new Action(() => _form.StartLoading()));
            else
                _form.StartLoading();
        }

        protected virtual void StopLoading()
        {
            if (_form.InvokeRequired)
                _form.Invoke(new Action(() => _form.StopLoading()));
            else
                _form.StopLoading();
        }

        #endregion
    }
}
