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

namespace SerializableStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CustomStyle s = new CustomStyle(typeof(Button));
            s.Setters.Add(new Setter(Button.HeightProperty, 25));

            string serializedStyle = StyleSerializer.SerializeStyle(s);
            mTextBox.Text = serializedStyle;
            CustomStyle de = StyleSerializer.DeserializeStyle(serializedStyle);
        }
    }
}
