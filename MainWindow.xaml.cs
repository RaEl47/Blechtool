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

            List<ListSurfaces> sheetProperties = new List<ListSurfaces>();
            sheetProperties.Add(new ListSurfaces("ohne Schliff"));
            sheetProperties.Add(new ListSurfaces("1-seitig geschliffen"));
            sheetProperties.Add(new ListSurfaces("quer geschliffen"));

            cbo_Box.ItemsSource = sheetProperties;
        }
    }

    public class ListSurfaces
    {        
        public string Surface { get; set; }        

        public ListSurfaces(string surface)
        {            
            Surface = surface;            
        }
    }
}
