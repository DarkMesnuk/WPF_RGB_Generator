using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Task_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public class ColorItem
    {
        public string Title { get; set; }
        public string Item_Color { get; set; }
    }

    public partial class MainWindow : Window
    {
        private byte Color_R, Color_G, Color_B, Alpha;
        private Color Color_Mix;

        public MainWindow()
        {
            InitializeComponent();
            Add_Button_Click(255, 255, 0, 0);
            Add_Button_Click(255, 0, 255, 0);
            Add_Button_Click(255, 0, 0, 255);

        }

        private void ColorChanger()
        {
            Alpha = Convert.ToByte(AlphaBar.Value);
            Color_R = Convert.ToByte(RedBar.Value);
            Color_G = Convert.ToByte(GreenBar.Value);
            Color_B = Convert.ToByte(BlueBar.Value);

            if (A_CheckBox.IsChecked == false)
            {
                Alpha = 0;
            }
            if (R_CheckBox.IsChecked == false)
            {
                Color_R = 0;
            }
            if (B_CheckBox.IsChecked == false)
            {
                Color_B = 0;
            }
            if (G_CheckBox.IsChecked == false)
            {
                Color_G = 0;
            }

            Color_Mix = Color.FromArgb(Alpha, Color_R, Color_G, Color_B);
            MixColor.Background = new SolidColorBrush(Color_Mix);
        }

        private void AlphaBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorChanger();

            Alpha = Convert.ToByte(AlphaBar.Value);
            A_CheckBox.Content = ($"Alpha : {Alpha}");
        }

        private void RedBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorChanger();

            Color_R = Convert.ToByte(RedBar.Value);
            R_CheckBox.Content = ($"Red : {Color_R}");
        }

        private void GreenBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorChanger();

            Color_G = Convert.ToByte(GreenBar.Value);
            G_CheckBox.Content = ($"Green : {Color_G}");
        }

        private void BlueBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorChanger();

            Color_B = Convert.ToByte(BlueBar.Value);
            B_CheckBox.Content = ($"Blue : {Color_B}");
        }

        private void A_CheckBox_Model(object sender, RoutedEventArgs e)
        {
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var hexString = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Alpha, Color_R, Color_G, Color_B);
            ColorList.Items.Add(new ColorItem() { Title = hexString, Item_Color = hexString });
        }

        private void Add_Button_Click(byte alpha, byte color_r, byte color_g, byte color_b)
        {
            var hexString = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", alpha, color_r, color_g, color_b);
            ColorList.Items.Add(new ColorItem() { Title = hexString, Item_Color = hexString });
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var listitem = sender as Button;
            ColorList.SelectedItem = listitem.DataContext;
            ColorList.Items.Remove(ColorList.SelectedItem);
        }







        private void ColorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void R_CheckBox_Model(object sender, RoutedEventArgs e)
        {
        }
        private void G_CheckBox_Model(object sender, RoutedEventArgs e)
        {
        }
        private void B_CheckBox_Model(object sender, RoutedEventArgs e)
        {
        }
    }
}
