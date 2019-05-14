using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataProject.Models
{
    public class DFA
    {
        public string Name { get; set; }
        public string StrDescription { get; set; }
        public List<State> States = new List<State>();
        public List<char> Alphabet { get; set; } = new List<char>();
        public int IntialState { get; set; }
        public List<int> FinalStates { get; set; } = new List<int>();
        public List<List<int>> TransitionFunction  { get; set; }

        public DFA()
        {

        }

        public DFA(string name, string strDes, IEnumerable<State> states, IEnumerable<char> alphabet, IEnumerable<int> finalStates, int intialState = 0)
        {
            Name = name;
            StrDescription = strDes;
            States = new List<State>(states);
            Alphabet = new List<char>(alphabet);
            FinalStates = new List<int>(finalStates);
            IntialState = intialState;
        }
        
        public bool CheckStr(string str)
        {
            var currentState = IntialState;
            foreach(var c in str)
            {
                if (States[currentState].Transitions.Keys.Contains(c))
                    currentState = this.States[currentState].Transitions[c];
                else return false;
                //if (index == -1) return false;
                //currentState = TransitionFunction[currentState][index];
            }
            if (FinalStates.Contains(currentState)) return true;
            return false;
        }
    }
}
