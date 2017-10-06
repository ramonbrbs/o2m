using Xamarin.Forms;

namespace Movel.Util
{
    public class Navigation
    {
        public static void AddToNavigation(INavigation navigation, Page nextPage, bool modal = false)
        {
            var stack = navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != nextPage.GetType())
            {
                if (modal)
                {
                    navigation.PushModalAsync(nextPage);
                }
                else
                {
                    navigation.PushAsync(nextPage);
                }
                
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    
                });

            }
        }
    }
}
