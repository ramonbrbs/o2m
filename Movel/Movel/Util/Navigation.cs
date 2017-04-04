using Xamarin.Forms;

namespace Movel.Util
{
    public class Navigation
    {
        public static void AddToNavigation(INavigation navigation, Page nextPage)
        {
            var stack = navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != nextPage.GetType())
            {
                navigation.PushAsync(nextPage);
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    
                });

            }
        }
    }
}
