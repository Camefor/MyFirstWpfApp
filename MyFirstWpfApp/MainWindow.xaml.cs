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

    public class MyButton : Button {
        public Type UserWindowType { get; set; }

        protected override void OnClick() {
            base.OnClick();
            Window win = Activator.CreateInstance(this.UserWindowType) as Window;
            if (win != null) {
                win.ShowDialog();
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public static string WindowTitle = "妳的的名字還在糾結我";
        public static string ShowTitle { get { return "誰試圖靠近妳，誰的聲音已經改變妳"; } }


        public MainWindow() {
            InitializeComponent();
        }

        private void btn1_Click(object sender , RoutedEventArgs e) {
            Human human = (Human)this.FindResource("human");
            MessageBox.Show(human.Child.Name);
        }

        private void Button_Click(object sender , RoutedEventArgs e) {
            string str = FindResource("myString") as string;
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
