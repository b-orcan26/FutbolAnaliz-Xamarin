using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FutbolAnalizXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakimIstatistikPage : ContentPage
    {
        private List<StackLayout> layoutList;
        public TakimIstatistikPage()
        {
            InitializeComponent();
            layoutList = new List<StackLayout>();
            layoutList.Add(layout_Son5Mac);
            layoutList.Add(layout_AU);
            layoutList.Add(layout_Goller);           
        }

        private void Image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void mainMenuClick(object sender, EventArgs e)
        {
            
        }

        private void ClickSon5Btn(object sender, EventArgs e)
        {
            
            layout_Son5Mac.IsVisible = true;
            layout_Goller.IsVisible = false;
            layout_AU.IsVisible = false;
            menu_Au.IsVisible = false;
            menu_goller.IsVisible = false;
        }

        private void ClickAUBtn(object sender, EventArgs e)
        {
            layout_Son5Mac.IsVisible = false;
            layout_Goller.IsVisible = false;
            layout_AU.IsVisible = false;
            menu_Au.IsVisible = true;
            menu_goller.IsVisible = false;
        }

        private void ClickGollerBtn(object sender, EventArgs e)
        {
            layout_Son5Mac.IsVisible = false;
            layout_Goller.IsVisible = false;
            layout_AU.IsVisible = false;
            menu_Au.IsVisible = false;
            menu_goller.IsVisible = true;
        }

        private void ClickGollerMenuItems(object sender, EventArgs e)
        {
            
          
            ChangeVisibility(sender, layout_Goller);
            
        }

        private void ClickAuMenuItems(object sender, EventArgs e)
        {
           /*
            layout_AU.IsVisible = false;
            menu_Au.IsVisible = false;


            layout_AU.IsVisible = true;
            menu_Au.IsVisible = true;
           */

            ChangeVisibility(sender, layout_AU);
            
            // v.IsVisible = true;
        }

        private void ChangeVisibility1(object sender , StackLayout layout)
        {
            var btn = (Button)sender;
            var parent = (StackLayout)btn.Parent;
            int index = parent.Children.IndexOf(btn);
            int i = 0;
            layout_AU.IsVisible = true;
            layout_Son5Mac.IsVisible = false;
            layout_Goller.IsVisible = false;
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


        private void ChangeVisibility(object sender , StackLayout layout)
        {
            var btn = (Button)sender;
            var parent = (StackLayout)btn.Parent;
            int index = parent.Children.IndexOf(btn);


            foreach (View item in layoutList)
            {
                if (item == layout)
                {
                    item.IsVisible = true;


                }
                else
                {
                    item.IsVisible = false;
                }

            }

            int i = 0;
            foreach (View item in layout.Children)
            {
                if (index == i)
                {
                    item.IsVisible = true;
                    
                   
                }
                else {
                item.IsVisible = false;
                }
                i++;
            }

    


        }

    }
}