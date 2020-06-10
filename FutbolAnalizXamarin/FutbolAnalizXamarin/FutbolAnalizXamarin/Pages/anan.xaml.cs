using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolAnalizXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class anan : ContentPage
    {
        public anan()
        {
            InitializeComponent();
           
        }

        private void ClickAuMenuItems(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var parent = (StackLayout)btn.Parent;
            int index = parent.Children.IndexOf(btn);
            int i = 0;
            foreach (View item in layout_AU.Children)
            {
                if (i == index)
                {
                    item.IsVisible = true;

                  
                }
                else
                {
                    item.IsVisible = false;
                }
                
                i++;
            }

        }

        private void ClickSon5Btn(object sender, EventArgs e)
        {
            layout_Son5Mac.IsVisible=true;
            layout_AU.IsVisible = false;
            layout_Goller.IsVisible = false;
        }

        private void ClickAUBtn(object sender, EventArgs e)
        {
            layout_Son5Mac.IsVisible = false;
            layout_AU.IsVisible = true;
            layout_Goller.IsVisible = false;
        }

        private void ClickGollerBtn(object sender, EventArgs e)
        {
            layout_Son5Mac.IsVisible = false;
            layout_AU.IsVisible = false;
            layout_Goller.IsVisible = true;
        }

        private void ClickGollerMenuItems(object sender, EventArgs e)
        {

        }
    }
}