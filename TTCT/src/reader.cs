using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace TTCT
{
    class Reader
    {
        private bool ignoreCase = false;
        private bool useStemmer = false;
        private PorterStemmer pStemmer = new PorterStemmer();

        public Reader()
        {

        }
        public Reader(bool ignoreCase, bool useStemmer)
        {
            this.ignoreCase = ignoreCase;
            this.useStemmer = useStemmer;
        }

        //Return a dll of all terms found
        public DoublyLinkedList getDLLOfTerms(string path)
        {
            DoublyLinkedList dll = new DoublyLinkedList();

            List<string> terms = getWordsInDir(path);

            foreach(string term in terms)
            {
                if(!dll.contains(term))
                {
                    dll.pushTail(term);
                }
            }

            return dll;
        }
        
        //Return a dll after removing found terms
        public DoublyLinkedList removeTermsFromDll(string path, DoublyLinkedList dll)
        {
            List<string> terms = getWordsInDir(path);

            foreach(string term in terms)
            {
                dll.remove(term);
            }

            return dll;
        }

        //Recursively store terms in a list of string
        public List<string> getWordsInDir(string path)
        {
            List<string> terms = new List<string>();

            if(Directory.Exists(path))
            {
                //Recurively call this function to add the words from the child dir
                foreach (string subDir in Directory.EnumerateDirectories(path))
                {
                    terms.AddRange(getWordsInDir(subDir));
                }

                foreach (string file in Directory.EnumerateFiles(path))
                {
                    terms.AddRange(getFileContent(file));
                }
            }
            else if(File.Exists(path))
            {
                terms.AddRange(getFileContent(path));
            }

            return terms;
        }

        //Open file and get all terms
        private List<string> getFileContent(string path)
        {
            List<string> contents = new List<string>();

            string fileContent = File.ReadAllText(path);
            string rgxContent = Regex.Replace(fileContent, "[^\\w]", " ");
            List<string> tmp = rgxContent.Split(' ').Distinct().ToList();

            if(useStemmer)
            {
                foreach(string term in tmp)
                {
                    contents.Add(pStemmer.StemWord(term).ToLower());
                }
            }
            else if(ignoreCase)
            {
                foreach(string term in tmp)
                {
                    contents.Add(term.ToLower());
                }
            }
            else
            {
                contents = tmp;
            }

            return contents;
        }
    }
}