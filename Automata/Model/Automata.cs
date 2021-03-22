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
        public List<string> passed;
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
        /*
        public void deleteRedundant() {
            for (int i =0; i<matrix.Count; i++) {
                for (int j = 0; j < matrix.ElementAt(i).Count; j++) {
                    string matrixValue = matrix.ElementAt(i).ElementAt(j);
                    if (!checkexist(matrixValue))
                    {

                    }
                    else {
                        passed.Add(matrixValue);
                    }
                }
            }
        }
        */
        /*
        public void deleteRedundant()
        {
            Boolean flag;
            for (int i = 0; i < matrix.Count; i++)
            {
                flag = false;
                for (int j = 0; j < matrix.ElementAt(i).Count && flag==false; j++)
                {
                    string matrixValue = matrix.ElementAt(i).ElementAt(j);
                 
                    if (j==0 && checkexist(matrixValue)==false && passed.Count > 0) {
                        flag = true;
                        j = matrix.ElementAt(i).Count;
                        break;
                    }
                    if (checkexist(matrixValue) == false)
                    {
                        passed.Add(matrixValue);
                    }


                }
            }
        }


        public Boolean checkexist(string elementToCheck) {
            Boolean value = false;
            for (int i = 0; i<passed.Count; i++) {
                if (passed.ElementAt(i).Equals(elementToCheck)) {
                    value = true;
                }
            }
            return value;
        }
        */
        public void deleteLines()
        {
            int count = 0;
            for (int k=0; k<count; k++) {
                List<string> connected = new List<string>();
                connected.Add(matrix.ElementAt(0).ElementAt(0));
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (isInList(matrix.ElementAt(i).ElementAt(0), connected))
                    {
                        for (int j = 0; j < matrix.ElementAt(i).Count; j++)
                        {
                            //A,B,1,F,3,D,4
                            int aux = (j * 2) + 1;
                            if (!isInList(matrix.ElementAt(i).ElementAt(aux), connected))
                            {
                                connected.Add(matrix.ElementAt(i).ElementAt(aux));
                                count++;
                            }
                        }
                    }
                }
            }
            
        }
        public Boolean isInList(string st, List<string> connected)
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

