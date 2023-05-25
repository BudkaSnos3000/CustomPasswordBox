using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();
            
        }
        public bool PassCheck = false;
        private void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(passwordBox, new object[] { start, length });
        }
        
        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            var template = EyeButton.Template;
            var myimage = (Image)template.FindName("EyeIcon", EyeButton);
            if (!PassCheck)
            {
                var bc = new BrushConverter();
                MainTextBox.Foreground = (Brush)bc.ConvertFrom("#68B8DD");
                MainTextBox.FontFamily = new FontFamily("C:\\Users\\Comp\\source\\repos\\WpfApp6\\WpfApp6\\password.ttf");
                //SetSelection(PasswordHide, PasswordHide.Password.Length, 0); //перенос курсора в конец
                BitmapImage image = new BitmapImage(new Uri(new Uri("pack://application:,,,/"), ".\\Pictures\\EyeClose.png"));
                myimage.Source = image;
                MainTextBox.Select(MainTextBox.Text.Length, 0);//перенос курсора в конец
                PassCheck = true;
            }
            else 
            {
                BitmapImage image = new BitmapImage(new Uri(new Uri("pack://application:,,,/"), ".\\Pictures\\EyeOpen.png"));
                myimage.Source = image;
                var bc = new BrushConverter();
                MainTextBox.FontFamily = new FontFamily("Arial");
                
                MainTextBox.Foreground = (Brush)bc.ConvertFrom("#000000");
                MainTextBox.Select(MainTextBox.Text.Length, 0);//перенос курсора в конец
                PassCheck = false;
            }
        }
    }
}
