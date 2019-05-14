using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataProject.Models
{
    public class Automata
    {
        public String Name { get; set; }
        public List<DFA> DFAs { get; set; }

        public string CheckStr(string str)
        {
            foreach(var dfa in DFAs)
            {
                var result = dfa.CheckStr(str);
                if (result)
                {
                    return dfa.StrDescription;
                }
            }
            return "";
        }
    }
}
