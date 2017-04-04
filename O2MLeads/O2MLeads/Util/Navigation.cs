using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace O2MLeads.Util
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
