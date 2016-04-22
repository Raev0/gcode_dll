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
using threeDPrinter;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gcode myGcode = new gcode();       
            // List<String> gcodefile = myGcode.gcodeExport();
            List<String> xyzcoordinate = myGcode.debugging();            
            foreach (String i in xyzcoordinate)
            {
                TextBlock textLine= new TextBlock ();
                textLine.Text = i;
                gcodelist.Items.Add(textLine);
            }   
        } 
    }
}
