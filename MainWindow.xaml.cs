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
using System.Windows.Media.Media3D;
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
            //List<ListThickness> sheetThickness = new List<ListThickness>();
            //sheetThickness.Add(new ListThickness(1));
            //sheetThickness.Add(new ListThickness(1.5));
            //sheetThickness.Add(new ListThickness(2));
            //sheetThickness.Add(new ListThickness(3));

            //cbo_Box_Thickness.ItemsSource = sheetThickness;
        }
        //TextBox Breite Eingabebeschränkung
        private void txt_Width_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        //TextBox Länge Eingabebeschränkung
        private void txt_Length_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        //Beschränkung Textbox ohne Buchstaben
        private readonly Regex rgx = new Regex("[0-9,]+");
        private bool IsTextAllowed(string text)
        {
            return rgx.IsMatch(text);
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            //Berechnung Volumen in dm³
            double number1 = Convert.ToDouble(txt_Width.Text);
            double number2 = Convert.ToDouble(txt_Length.Text);
            double number3 = Convert.ToDouble(cbo_Box_Thickness.Text);
            double volume = number1 * number2 * number3 / 1000000;
            //Masse in kg
            double weight = volume * 7.9;

            //1.4301 oder 1.4404 mit oder ohne Schliff
            double materialprice;
            if (rb_V2A.IsChecked == true)
            {
                if (cbo_Box_Surface.Text == "ohne Schliff")
                {
                    materialprice = 3.5;
                    double result = weight * materialprice;
                    txt_Result.Text = result.ToString();
                }
                else if (cbo_Box_Surface.Text == "1-seitig geschliffen")
                {
                    materialprice = 4;
                    double result = weight * materialprice;
                    txt_Result.Text = result.ToString();
                }
            }
            else if (rb_V4A.IsChecked == true) 
            {
                if (cbo_Box_Surface.Text == "ohne Schliff")
                {
                    materialprice = 7;
                    double result = weight * materialprice;
                    txt_Result.Text = result.ToString();
                }
                else if (cbo_Box_Surface.Text == "1-seitig geschliffen")
                {
                    materialprice = 7.5;
                    double result = weight * materialprice;
                    txt_Result.Text = result.ToString();
                }
            }      
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
    

    //public class ListThickness
    //{
    //    public double Thickness { get; set; }
    //    public ListThickness(double thickness)
    //    {
    //        Thickness = thickness;
    //    }
    //}
}
