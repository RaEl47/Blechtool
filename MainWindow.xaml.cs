using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //ComboBox mit Oberflächen
            List<ListSurfaces> sheetSurfaces = new List<ListSurfaces>();
            sheetSurfaces.Add(new ListSurfaces("ohne Schliff"));
            sheetSurfaces.Add(new ListSurfaces("1-seitig geschliffen"));
            sheetSurfaces.Add(new ListSurfaces("quer geschliffen"));

            cbo_Box_Surface.ItemsSource = sheetSurfaces;

            //ComboBox mit Blechdicken
            List<ListThickness> sheetThickness = new List<ListThickness>();
            sheetThickness.Add(new ListThickness(1));
            sheetThickness.Add(new ListThickness(1.5));
            sheetThickness.Add(new ListThickness(2));
            sheetThickness.Add(new ListThickness(3));

            cbo_Box_Thickness.ItemsSource = sheetThickness;

            //TextBox Breite Inhaltsbeschränkung

        }

        private void txt_Width_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }
        private readonly Regex rgx = new Regex("[0-9.]+");
        private bool IsTextNumeric(string text)
        {
            return double.TryParse(text, out _);
        }

        private void txt_Width_SelectionChanged(object sender, RoutedEventArgs e)
        {

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
    public class ListThickness
    {
        public double Thickness { get; set; }
        public ListThickness(double thickness)
        {
            Thickness = thickness;
        }
    }
}
