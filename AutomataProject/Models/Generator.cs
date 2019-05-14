using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomataProject.Models;

public class node{
    public string input;
    public string repetition;
    public node(string _input,string _repetition){
        input = _input;
        repetition = _repetition;
    }
}
namespace AutomataProject.Models
{
    public class Generator{
        public static DFA generateKeyWordDFA(){
            List<string> words = new List<string>() { "abstract","boolean","break","byte","case","catch","const","continue",
                "default","do", "double", "final", "finally","float","implements","import","instanceof","int","interface","this","throw","throws" };
            Trie.counter = 0;
            Trie.genratedDFA = new DFA();
            Trie trie = new Trie();
            foreach(string word in words){
                List<node> wordStringList = new List<node>();
                foreach(char c in word.ToList()){
                    wordStringList.Add(new node(c.ToString(),""));
                }
                trie.push(wordStringList);
            }
            trie.generateDFA();
            for (int i = 'a'; i <= 'z'; i++) Trie.genratedDFA.Alphabet.Add((char)(i));
            Trie.genratedDFA.Name = "Keywords DFA";
            Trie.genratedDFA.StrDescription = "this word is keyword";
            Trie.genratedDFA.IntialState = 0;
            return Trie.genratedDFA;
        }
        public static DFA generateNumbersDFA(){
            Trie.counter = 0;
            Trie.genratedDFA = new DFA();
            Trie trie = new Trie();
            trie.push(new List<node>() { new node ("0123456789","0123456789") });
            trie.push(new List<node>() { new node("0123456789", "0123456789"), new node(".",""),new node("0123456789", "0123456789") });
            trie.generateDFA();
            for (int i = 0 ; i <= 9; i++) Trie.genratedDFA.Alphabet.Add((char)(i));
            Trie.genratedDFA.Alphabet.Add('.');
            Trie.genratedDFA.Name = "Number DFA";
            Trie.genratedDFA.StrDescription = "this is a valid Number";
            Trie.genratedDFA.IntialState = 0;
            return Trie.genratedDFA;
        }
        public static DFA generateCommentsDFA()
        {
            Trie.counter = 0;
            Trie.genratedDFA = new DFA();
            Trie trie = new Trie();
            string any="";
            for (int i = 33; i < 130; i++) any += (char)(i);
            any = any.Remove(any.IndexOf('*'), 1);
            any = any.Remove(any.IndexOf('/'), 1);

            //------ Kais & Loauy Work ----------
            any += (char) 13;
            any += (char) 32;


            //----------------------------------
            trie.push(new List<node>() { new node("/",""), new node("*",""),new node(any,any),new node("*",""),new node("/","") });
            trie.push(new List<node>() { new node("/",""), new node("/",""),new node(any,any) });
            trie.generateDFA();
            for (int i = 0; i <any.Length; i++) Trie.genratedDFA.Alphabet.Add(any[i]);
            Trie.genratedDFA.Alphabet.Add('/');
            Trie.genratedDFA.Alphabet.Add('*');
            Trie.genratedDFA.Name = "comment DFA";
            Trie.genratedDFA.StrDescription = "this is a comment";
            Trie.genratedDFA.IntialState = 0;
            return Trie.genratedDFA;
        }
        public static DFA generateDeclareVariableDFA()
        {
            Trie.counter = 0;
            Trie.genratedDFA = new DFA();
            Trie trie = new Trie();
            string any = "";
            for (int i = 33; i < 130; i++) any += (char)(i);
            any = any.Remove(any.IndexOf('*'), 1);
            any = any.Remove(any.IndexOf('/'), 1);
            string alphabet="";

            for (int i = 'a'; i <= 'z'; i++) { alphabet += (char)(i); alphabet += (char)(i) - 'a' + 'A'; }
            List<List<node>> type         = new List<List<node>>();
            List<List<node>> NameValue    = new List<List<node>>() ;
            List<List<node>> comment      = new List<List<node>>();
            //int
            type.Add(new List<node>() { new node("i",""), new node("n",""), new node("t","")});
            //double
            type.Add(new List<node>() { new node("d", ""), new node("o", ""), new node("u", ""), new node("b", ""), new node("l", ""), new node("e", "") });
            //long
            type.Add(new List<node>() { new node("l", ""), new node("o", ""), new node("n", ""), new node("g", "") });
            //float
            type.Add(new List<node>() { new node("f", ""), new node("l", ""), new node("o", ""), new node("a", ""), new node("t", "") });

            NameValue.Add(new List<node>() { new node(" ",""), new node(alphabet,""), new node(alphabet + "0123456789", alphabet + "0123456789"),
                new node("=",""), new node("0123456789", "0123456789"),new node(".",""), new node("0123456789","0123456789"),new node(";","")});
            NameValue.Add(new List<node>() { new node(" ",""), new node(alphabet,""), new node(alphabet + "0123456789", alphabet + "0123456789"),
                new node("=",""), new node("0123456789", "0123456789"),new node(";","")});

            comment.Add(new List<node>() { new node("/",""), new node("*",""), new node(any,any), new node("*",""), new node("/","") });
            comment.Add(new List<node>() { new node("/", ""), new node("/", ""), new node(any, any) });


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        List<node> current = type[i];
                        current.AddRange(NameValue[j]);
                        trie.push(current);
                        current.AddRange(comment[k]);
                        trie.push(current);
                    }
                }
            }
            trie.generateDFA();
            for (int i = 0; i < any.Length; i++) Trie.genratedDFA.Alphabet.Add(any[i]);
            Trie.genratedDFA.Alphabet.Add('/');
            Trie.genratedDFA.Alphabet.Add('*');
            Trie.genratedDFA.Name = "declare variable DFA";
            Trie.genratedDFA.StrDescription = "this is a valid declartion";
            Trie.genratedDFA.IntialState = 0;
            return Trie.genratedDFA;
        }
    }
}
