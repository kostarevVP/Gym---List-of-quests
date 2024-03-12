namespace WKosArch.UIService.Views.Widgets
{
    public interface IWidget : IView { }

    public interface IWidget<TWidgetViewModel> : IView<TWidgetViewModel>, IWidget where TWidgetViewModel : WidgetViewModel { }
}