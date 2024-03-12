namespace WKosArch.UIService.Views
{
    public static class ViewExtensions
    {
        public static T As<T>(this IView view) where T : IView
        {
            return (T)view;
        }
    }
}