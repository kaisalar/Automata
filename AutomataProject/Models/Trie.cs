using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataProject.Models
{
    public class Trie
    {
        public static int counter = 0;
        Dictionary<string ,Trie> childs;
        Dictionary<string, Trie> repetition;
        bool end;
        int index;
        public Trie(){
            childs = new Dictionary<string,Trie>();
            repetition = new Dictionary<string, Trie>();
            index = counter++;
            end = false;
        }
        public void push(List<node> states, int id = 0) {
            if (id>0) {
                string repet = states[id - 1].repetition;
                repetition[repet] = this;
            }
            if (id == states.Count()) {
                end = true;
                return;
            }
            // repetition handling 
            
            // childs handling
            string to = states[id].input;
            if (!childs.Keys.Contains(to)) {
                childs[to] = new Trie();
            }
            childs[to].push(states, id + 1);
        }
        public static DFA genratedDFA = new DFA();
        public void generateDFA(){
            State currentState = new Models.State();
            currentState.Name = "q" + index;
            genratedDFA.States.Add(currentState);
            if (end){
                genratedDFA.FinalStates.Add(index);
            }
            // repetition handling 
            foreach (var repet in repetition.Keys){
                foreach (char input in repet){
                    currentState.Transitions[input] = index;
                }
            }
            // childs handling 
            foreach (var child in childs){
                foreach (char input in child.Key){
                    currentState.Transitions[input] = child.Value.index;
                }
                child.Value.generateDFA();
            }
        }
    }
}
