using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;
using AutomataProject.Models;

namespace AutomataProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Automata automata;
        public DFA dfa;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void selectAutomataButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                var data = File.ReadAllText(fileDialog.FileName);
                dfa = JsonConvert.DeserializeObject<DFA>(data);
                automataNameTextBlock.Text = dfa.Name;
                strTextBox.IsEnabled = true;
            }
        }

        private void strTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (sender as TextBox).Text;
            var result = dfa.CheckStr(text);
            if (!result)//string.IsNullOrWhiteSpace(result))
            {
                strResult.Text = "Error: Can't recognize the string :(";
                strResult.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }
            strResult.Text = dfa.StrDescription + " :)";
            strResult.Foreground = new SolidColorBrush(Colors.Green);
        }

        private void generateAutomata_Click(object sender, RoutedEventArgs e)
        {
            CreateJsonWindow window = new CreateJsonWindow();
            window.ShowDialog();
        }

        private void drawAutomata_Click(object sender, RoutedEventArgs e)
        {
            //Window window = new Window();
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "C");
            //viewer.Graph = graph;
            //window.Content = viewer;
            //window.Show();
            DrawDfaWindow window = new DrawDfaWindow(this.dfa);
            window.ShowDialog();
         
        }
    }
}
