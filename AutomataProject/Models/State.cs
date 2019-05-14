using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataProject.Models
{
    public class State
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<char, int> Transitions = new Dictionary<char, int>();
        public State()
        {

        }

        public State(string name)
        {
            Name = name;
        }

        public State(string name, string description){
            Name = name;
            Description = description;
        }

        public void addTransition(char input, int nextStateIndex)
        {
            Transitions.Add(input, nextStateIndex);
        }
    }
}
