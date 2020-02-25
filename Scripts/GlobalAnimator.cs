using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _200201_MY_YellowLead_UWP.Scripts
{
    public class GlobalAnimator
    {
        public static async void ScaleImage(Image i, float centerPoint = 0)
        {
           i.Scale(scaleX: 1.25f, scaleY: 1.25f, centerX: centerPoint, centerY: centerPoint, duration: 300, delay: 0, easingType: EasingType.Default).Start();
            await System.Threading.Tasks.Task.Delay(300);
           i.Scale(scaleX: 1, scaleY: 1f, centerX: 0, centerY: 0, duration: 300, delay: 0, easingType: EasingType.Default).Start();
        }

        public static async void ScaleControl(Button c)
        {
            c.Scale(scaleX: 1.25f, scaleY: 1.25f, centerX: 0, centerY: 0, duration: 300, delay: 0, easingType: EasingType.Default).Start();
            await System.Threading.Tasks.Task.Delay(300);
            c.Scale(scaleX: 1, scaleY: 1f, centerX: 0, centerY: 0, duration: 300, delay: 0, easingType: EasingType.Default).Start();
        }
    }
}
