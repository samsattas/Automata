using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata.Model
{
    class Automata
    {
        public List<List<string>> matrix;
        public Automata()
        {
            matrix = new List<List<string>>();
        }

        public void resetMatrix(string line)
        {
            matrix = new List<List<string>>();
        }

        public List<string> lineToArray(string inLine)
        {
            List<string> lineArray = new List<string>();
            String[] auxArray = inLine.Split(',');

            for (int i = 0; i < auxArray.Length; i++)
            {
                lineArray.Add(auxArray[i]);
            }

            return lineArray;
        }

    }
}
