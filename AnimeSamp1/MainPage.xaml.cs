using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace AnimeSamp1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private DoubleAnimation makeAnimeSize()
        {

            var szw = new DoubleAnimation() { BeginTime = TimeSpan.FromMilliseconds(0), Duration = new Windows.UI.Xaml.Duration(TimeSpan.FromMilliseconds(200)), From = 0.0, To = 300.0, EnableDependentAnimation = true };
            Storyboard.SetTarget(szw, colbar);
            Storyboard.SetTargetProperty(szw, "Width");

            szw.FillBehavior = FillBehavior.HoldEnd;
            return szw;

        }

        private DoubleAnimation makeAnimeMove(double start , double end )
        {
            var da = new DoubleAnimation() { BeginTime = TimeSpan.FromMilliseconds(0), Duration = new Windows.UI.Xaml.Duration(TimeSpan.FromMilliseconds(200)), From = start, To = end, EnableDependentAnimation = true };
            Storyboard.SetTarget(da, colbar);
            Storyboard.SetTargetProperty(da, "(UIElement.Projection).(PlaneProjection.LocalOffsetY)");
            da.FillBehavior = FillBehavior.HoldEnd;

            return da;

        }


        private void button_click1(object sender, RoutedEventArgs e)
        {
            if (myStoryboard.GetCurrentState() != ClockState.Stopped)
            {
                myStoryboard.Stop();
                myStoryboard.Children.RemoveAt(0);
                myStoryboard.Children.RemoveAt(0);
            }

            var da = makeAnimeMove( 0.0 , 50.0 );
            myStoryboard.Children.Add(da);

            var szw = makeAnimeSize();
            myStoryboard.Children.Add(szw);
            myStoryboard.Begin();


        }

    }

}
