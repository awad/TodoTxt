using System;
using System.Windows.Navigation;

namespace TodoTxt
{
    public static class NavigationManager
    {
        private static NavigationService _navService;
        public const string NoCurrentPage = "NIL";
        internal static string CurrentPage { get; private set; }

        public static void NavigateToPage(NavigationService navigationService, string pageUrl, UriKind relative)
        {
            _navService = navigationService;
            if (!(pageUrl.Equals(navigationService.CurrentSource.ToString())))
            {
                try
                {
                    _navService.Navigate(new Uri(pageUrl, relative));
                }
                catch (Exception ex)
                {
                    CurrentPage = NoCurrentPage;
                    throw;
                }
            }
            CurrentPage = pageUrl;
        }

        public static void ForceNavigateToPage(string pageUrl, UriKind kind)
        {
            try
            {
                _navService.Navigate(new Uri(pageUrl, kind));
            }
            catch (Exception ex)
            {
                CurrentPage = NoCurrentPage;
                throw;
            }
            CurrentPage = pageUrl;
        }
    }
}