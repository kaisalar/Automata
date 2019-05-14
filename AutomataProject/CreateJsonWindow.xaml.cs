using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using Newtonsoft.Json;
using Microsoft.Win32;

namespace AutomataProject
{
    /// <summary>
    /// Interaction logic for CreateJsonWindow.xaml
    /// </summary>
    public partial class CreateJsonWindow : Window
    {
        private DFA dfa = new DFA();

        public CreateJsonWindow(){
            InitializeComponent();
            //DFA NumbersDFA = Generator.generateDeclareVariableDFA();
            //foreach(var state in NumbersDFA.States){
            //    Console.WriteLine(state.Name + ":");
            //    foreach(var nextState in state.Transitions){
            //        Console.Write(nextState.Key + "->" + NumbersDFA.States[nextState.Value].Name + ", ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("final State:");
            //foreach (var finalState in NumbersDFA.FinalStates){
            //    Console.Write(finalState +  " ");
            //}

        }

        //private void addNewState_Click(object sender, RoutedEventArgs e)
        //{
        //    State state = new State();
        //    StackPanel mainStack = new StackPanel();
        //    mainStack.Margin = new Thickness(10);
        //    TextBlock nameTextBlock = new TextBlock();
        //    nameTextBlock.Text = "State Name";
        //    mainStack.Children.Add(nameTextBlock);
        //    TextBox nameTextBox = new TextBox();
        //    nameTextBox.TextChanged += (s, a) =>
        //    {
        //        state.Name = nameTextBox.Text;
        //    };
        //    mainStack.Children.Add(nameTextBox);
        //    Button addTransitionButton = new Button();
        //    addTransitionButton.Content = "Add New Transition";
        //    StackPanel transitionsStackPanel = new StackPanel();
        //    addTransitionButton.Click += (s, a) => {
        //        StackPanel panel = new StackPanel();
        //        panel.Orientation = Orientation.Horizontal;
        //        TextBlock inputTextBlock = new TextBlock();
        //        inputTextBlock.Text = "Input";
        //        TextBox inputTextBox = new TextBox();
        //        TextBlock nextStateTextBlock = new TextBlock();
        //        nextStateTextBlock.Text = "Next State";
        //        TextBox nextStateTextBox = new TextBox();
        //        inputTextBox.TextChanged += (s1, a1) =>
        //        {
        //            state.Transitions[inputTextBox.Text[0]] = -1;
        //        };
        //        nextStateTextBox.TextChanged += (s2, a2) =>
        //        {
        //           // nextState
        //            state.Transitions[inputTextBox.Text[0]] = int.Parse(nextStateTextBox.Text);
        //        };
                
        //        panel.Children.Add(inputTextBlock);
        //        panel.Children.Add(inputTextBox);
        //        panel.Children.Add(nextStateTextBlock);
        //        panel.Children.Add(nextStateTextBox);
        //        transitionsStackPanel.Children.Add(panel);
        //    };
        //    mainStack.Children.Add(addTransitionButton);
        //    mainStack.Children.Add(transitionsStackPanel);
        //    dfaStates.Children.Add(mainStack);
        //}

        //private void dfaName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    dfa.Name = dfaName.Text;
        //}

        //private void dfaDes_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    dfa.StrDescription = dfaDes.Text;
        //}

        private void keywordsButton_Click(object sender, RoutedEventArgs e)
        {
            var keywordsDFA = Generator.generateKeyWordDFA();
            var data = JsonConvert.SerializeObject(keywordsDFA);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Text file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, data);
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.DefaultExt = ".json";
            //saveFileDialog.Filter = "Text file (*.json)|*.json";
            ////if (saveFileDialog.ShowDialog() == true)
            //{
            //    string fileName = saveFileDialog.FileName;
            //    var keywordsDFA = Generator.generateKeyWordDFA();
            //    var data = JsonConvert.SerializeObject(keywordsDFA);
            //    try
            //    {
            //        // Check if file already exists. If yes, delete it.     
            //        if (File.Exists(fileName))
            //        {
            //            File.Delete(fileName);
            //        }

            //        // Create a new file     
            //        using (FileStream fs = File.Create(fileName))
            //        {
            //            // Add some text to file    
            //            Byte[] byteData = new UTF8Encoding(true).GetBytes(data);
            //            fs.Write(byteData, 0, byteData.Length);
            //        }
            //    }
            //    catch (Exception Ex)
            //    {
            //        Console.WriteLine(Ex.ToString());
            //    }
            //}
        }

        private void numbersButton_Click(object sender, RoutedEventArgs e)
        {
            var keywordsDFA = Generator.generateNumbersDFA();
            var data = JsonConvert.SerializeObject(keywordsDFA);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Text file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, data);
        }

        private void commentsButton_Click(object sender, RoutedEventArgs e)
        {
            var keywordsDFA = Generator.generateCommentsDFA();
            var data = JsonConvert.SerializeObject(keywordsDFA);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Text file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, data);
        }

        private void declareButton_Click(object sender, RoutedEventArgs e)
        {
            var keywordsDFA = Generator.generateDeclareVariableDFA();
            var data = JsonConvert.SerializeObject(keywordsDFA);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Text file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, data);
        }
    }
}
