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
using System.Windows.Shapes;
using AutomataProject.Models;

namespace AutomataProject
{
    /// <summary>
    /// Interaction logic for DrawDfaWindow.xaml
    /// </summary>
    public partial class DrawDfaWindow : Window
    {
        //public DFA dfa;
        public DrawDfaWindow(DFA dfa)
        {
            InitializeComponent();
            //this.dfa = dfa;

            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            foreach(var state in dfa.States)
            {
                foreach(var key in state.Transitions.Keys)
                {
                    //var label = new Microsoft.Msagl.Drawing.Label();
                    //label.IsVisible = true;
                    //label.Text = key.ToString();
                    //Microsoft.Msagl.Drawing.Edge edge = new Microsoft.Msagl.Drawing.Edge(state.Name, key.ToString(), dfa.States[state.Transitions[key]].Name);
                    //graph.AddEdge()
                    graph.AddEdge(state.Name, key.ToString(), dfa.States[state.Transitions[key]].Name);
                    
                }
                foreach(var finalState in dfa.FinalStates)
                {
                   // var node =
                       // graph.FindNode(dfa.States[finalState].Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    //node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.DodgerBlue;
                }
            }
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "C");
            gViewer.Graph = graph;
        }


    }
}
