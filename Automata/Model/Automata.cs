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
        public List<string> connected;
        public Automata()
        {
            matrix = new List<List<string>>();
        }

        public void resetMatrix(string line)
        {
            matrix = new List<List<string>>();
        }

        public void lineToArray(string inLine)
        {
            List<string> lineArray = new List<string>();
            String[] auxArray = inLine.Split(',');

            for (int i = 0; i < auxArray.Length; i++)
            {
                lineArray.Add(auxArray[i]);
            }
            matrix.Add(lineArray);
        }
        
        public void deleteUnconnectedLines()
        {
            
            int count = 0;
            //se realiza este procedimiento hasta que no haya ningun cambio para asegurarse que 
            while (count > 0) {
                //se utiliza este count para verificar si hubo algun cambio
                count = 0;
                //List<string> connected = new List<string>();
                connected.Add(matrix.ElementAt(0).ElementAt(0));
                for (int i = 0; i < matrix.Count; i++){
                    if (isInList(matrix.ElementAt(i).ElementAt(0))){
                        int lineLength = (matrix.ElementAt(i).Count - 1) / 2;
                        for (int j = 0; j < lineLength; j++){
                            
                            int aux = (j * 2) + 1;
                            if (!isInList(matrix.ElementAt(i).ElementAt(aux))){
                                connected.Add(matrix.ElementAt(i).ElementAt(aux));
                                count++;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.Count; i++) {
                string nodeToDelete = matrix.ElementAt(i).ElementAt(0);
                if (isInList(nodeToDelete)==false) {
                    matrix.RemoveAt(i);
                }
               
            }   
        }
        public Boolean isInList(string st)
        {
            Boolean isIn = false;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (connected.ElementAt(i) == st)
                {
                    isIn = true;
                }
            }
            return isIn;
        }





    }
}

