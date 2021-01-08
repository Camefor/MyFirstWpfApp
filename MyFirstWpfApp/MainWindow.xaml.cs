using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace MyFirstWpfApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn1_Click(object sender , RoutedEventArgs e) {
            Human human = (Human)this.FindResource("human");
            MessageBox.Show(human.Child.Name);
        }
    }

    [TypeConverter(typeof(StringToHumanTypeConverter))]
    public class Human {
        public string Name { get; set; }
        public Human Child { get; set; }

    }

    public class StringToHumanTypeConverter : TypeConverter {
        public override object ConvertFrom(ITypeDescriptorContext context , CultureInfo culture , object value) {
            if (value is string) {
                Human h = new Human();
                h.Name = value as string;
                return h;
            }
            return base.ConvertFrom(context , culture , value);
        }
    }
}
