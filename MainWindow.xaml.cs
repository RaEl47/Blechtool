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

namespace Blechtool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<SheetProperties> sheetProperties = new List<SheetProperties>();
            sheetProperties.Add(new SheetProperties(null, "ohne Schliff", 0));
            sheetProperties.Add(new SheetProperties(null, "1-seitig geschliffen", 0));

            cbo_Box.ItemsSource = sheetProperties;
        }
    }

    public class SheetProperties
    {
        public string Material {  get; set; }
        public string Surface { get; set; }
        public decimal Thickness { get; set; }

        public SheetProperties(string material, string surface, decimal thickness)
        {
            Material = material;
            Surface = surface;
            Thickness = thickness;
        }
    }
}
