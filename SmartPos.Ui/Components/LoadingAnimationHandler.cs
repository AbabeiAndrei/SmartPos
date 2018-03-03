namespace SmartPos.Ui.Components
{
    public class LoadingAnimationHandler : ILoadingToken
    {
        private readonly BaseForm _form;
        private bool _loading;
        
        public bool Loading
        {
            get => _loading;
            set
            {
                if(!_loading && value)
                    _form.StartLoading();
                else if(_loading && !value)
                    _form.StopLoading();

                _loading = value;
            }
        }
        public int TimeOut { get; set; }

        public LoadingAnimationHandler(BaseForm form)
        {
            _form = form;
        }
    }
}
