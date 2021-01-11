namespace UI.Views
{
    public class BaseGenericView<TModel> : BaseView
        where TModel : ICustomModel
    {
        protected TModel Model;
        
        protected override void Process(ICustomModel model)
        {
            Model = (TModel) model;
            OnInitialize(Model);
            
            base.Process(model);
        }

        protected virtual void OnInitialize(TModel model)
        {
            
        }
    }
}