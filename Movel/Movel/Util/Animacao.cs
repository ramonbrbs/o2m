using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movel.Util
{
    public class Animacao
    {
        public static async void FadeOutIn(Layout<View> i)
        {
            if (!i.AnimationIsRunning("FadeTo"))
            {
                await i.FadeTo(0.5, 200);
                await i.FadeTo(1, 200);


            }
        }
        public static async void FadeOutIn(Image i)
        {
            if (!i.AnimationIsRunning("FadeTo"))
            {
                await i.FadeTo(0.5, 200);
                await i.FadeTo(1, 200);

            }
        }
    }
}
