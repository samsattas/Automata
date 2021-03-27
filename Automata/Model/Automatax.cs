using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata.Model
{
    class Automatax
    {
        public List<List<string>> matrix;
        public List<string> connected;
        public Automatax()
        {
            connected = new List<string>();
            matrix = new List<List<string>>();
        }

        public void start()
        {
            //deleteUnconnectedLines();
            test();
            List<List<string>> finalOutput = firstPartitioning();
            testPart(finalOutput);
            finalOutput = partitioningX(finalOutput);
            testPart(finalOutput);
            joinElements(finalOutput);
            cleanFinalMatrix();
            test();
        }


        public void test()
        {
            string auxMatrix = "{";
            for (int i = 0; i < matrix.Count; i++)
            {
                auxMatrix += "{" + matrix.ElementAt(i).ElementAt(0);
                for (int j = 1; j < matrix.ElementAt(i).Count; j++)
                {

                    auxMatrix += "," + matrix.ElementAt(i).ElementAt(j);
                }
                auxMatrix += "}";
            }
            auxMatrix += "}";

            Console.WriteLine(auxMatrix);
        }

        public void testPart(List<List<string>> p1)
        {
            string aux = "{";
            for(int i = 0; i < p1.Count; i++)
            {
                aux += "{" + p1.ElementAt(i).ElementAt(0);
                for (int j = 1; j < p1.ElementAt(i).Count; j++)
                {
                    aux += "," + p1.ElementAt(i).ElementAt(j);
                }
                aux += "}";
            }
            aux += "}";

            Console.WriteLine(aux);
        }



        public void resetMatrix(string line)
        {
            matrix = new List<List<string>>();
        }

        
        //Converts the user input from a string to an array and add it to the matrix
        public void lineToArray(string inLine)
        {
            List<string> lineArray = new List<string>();
            string[] auxArray = inLine.Split(',');

            for (int i = 0; i < auxArray.Length; i++)
            {
                lineArray.Add(auxArray[i]);
            }
            matrix.Add(lineArray);

            test();
        }
        

        public void deleteUnconnectedLines()
        {
            //This count is used to verify if there is any changes
            int count = 1;
            
            //This while is used to add the connected states to a list
            while (count > 0) {
                //This count is reseted every time
                count = 0;
                connected.Add(matrix.ElementAt(0).ElementAt(0));
                for (int i = 0; i < matrix.Count; i++){

                    Console.WriteLine(isInList(matrix.ElementAt(i).ElementAt(0)));//eesseses

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

            //This for purge all the unconnected states from the matrix
            for (int i = 0; i < matrix.Count; i++) {
                string nodeToDelete = matrix.ElementAt(i).ElementAt(0);
                if (isInList(nodeToDelete)==false) {
                    matrix.RemoveAt(i);
                }
               
            }   
        }

        //This method verifies if the string "st" is in the list of connected states
        public bool isInList(string st)
        {
            bool isIn = false;
            for (int i = 0; i < connected.Count; i++)
            {
                if (connected.ElementAt(i) == st)
                {
                    isIn = true;
                }
            }
            return isIn;
            
        }

        public List<List<string>> firstPartitioning()
        {
            //This returns "part"
            List<List<string>> part = new List<List<string>>();
            //part.ElementAt(i).ElementAt(0) to get the state name
            List<string> auxList = new List<string>();

            //Add the initial state because it always be in and at 1st position
            auxList.Add(matrix.ElementAt(0).ElementAt(0));
            part.Add(auxList);
            for(int i = 1; i < matrix.Count; i++)
            {
                bool auxChanges = false;
                //start moving and comparing//
                for(int j = 0; j < part.Count; j++)
                {
                    //compare the state name of a line of the matrix 
                    //with the states added in the partitioning 1
                    //input: C, {{A,B}{D}}, compare: A<->C, if not the same outputs, then compare: C<->D
                    if(compareLinesOutputs(part.ElementAt(j).ElementAt(0), matrix.ElementAt(i).ElementAt(0))){
                        //if the states has the same outputs, the state is added together
                        part.ElementAt(j).Add(matrix.ElementAt(i).ElementAt(0));
                        auxChanges = true;
                    }
                }
                //if the outputs are diferent from the actual ones, it is added in a new group {{A,B}{"here"}}
                if(!auxChanges)
                {
                    List<string> auxListToAdd = new List<string>();
                    auxListToAdd.Add(matrix.ElementAt(i).ElementAt(0));
                    part.Add(auxListToAdd);
                }
                //End of comparing and adding the line 'i' os the matrix
            }
            //return the list of P1
            return part;
            
        }

        //Return T if they have the same outputs and order, and F if not
        public bool compareLinesOutputs(string x, string y)
        {
            string outX = "";
            string outY = "";
            for(int i = 0; i < matrix.Count; i++)
            {
                //######################################################################
                //AQUI SE PODRIA HACER UN CONTADOR PARA SALIR APENAS SE HAYAN ENCONTRADO

                //process to get the outputs of the line X
                if(matrix.ElementAt(i).ElementAt(0) == x) //If the state name is equal to the input X
                {
                    //A,D,2,E,3
                    int auxInt = (matrix.ElementAt(i).Count - 1) / 2;
                    for(int j = 1; j <= auxInt; j++)
                    {
                        //The outputs of the state are added
                        outX += matrix.ElementAt(i).ElementAt(2 * j);
                    }
                }

                //process to get the outputs of the line Y
                if (matrix.ElementAt(i).ElementAt(0) == y)//If the state name is equal to the input X
                {
                    int auxInt = (matrix.ElementAt(i).Count - 1) / 2;
                    for (int j = 1; j <= auxInt; j++)
                    {
                        //The outputs of the state are added
                        outY += matrix.ElementAt(i).ElementAt(2 * j);
                    }
                }
            }
            if (outX == outY)//The "x" and "y" outputs are the same
            {
                return true;
            }
            else //The outputs are diferent
            {
                return false;
            }
        }


        public List<List<string>> partitioning(List<List<string>> p1)
        {
            bool changes = true;
            while (changes)
            {
                changes = false;
                for (int i = 0; i < p1.Count && !changes; i++)
                {
                    for (int j = 1; j < p1.ElementAt(i).Count; j++)
                    {
                        string a1 = getOutputStatesPosition(p1.ElementAt(i).ElementAt(0), p1);
                        string a2 = getOutputStatesPosition(p1.ElementAt(i).ElementAt(j), p1);
                        if (a1 != a2)
                        {
                            bool added = false;
                            for(int k = 0; k < p1.Count; k++)
                            {
                                if(a2 ==  getOutputStatesPosition(p1.ElementAt(k).ElementAt(0), p1))
                                {
                                    p1.ElementAt(k).Add(a2);
                                    added = true;
                                }
                            }

                            if (!added)
                            {
                                List<string> newList = new List<string>();
                                newList.Add(p1.ElementAt(i).ElementAt(j));

                                //Here adds a new group on the partitioning
                                p1.Add(newList);
                            }
                            

                            //Here removes the element that was moved
                            p1.ElementAt(i).RemoveAt(j);
                            
                            changes = true;
                        }
                    }
                }
            }
            //Return the list finished
            return p1;
            
        }

        public List<List<string>> partitioningX(List<List<string>> p1)
        {
            bool changes = true;
            while (changes)
            {
                changes = false;
                for (int i = 0; i < p1.Count; i++)
                {
                    for (int j = 1; j < p1.ElementAt(i).Count; j++)
                    {
                        
                        string a1 = getOutputStatesPosition(p1.ElementAt(i).ElementAt(0), p1);
                        string a2 = getOutputStatesPosition(p1.ElementAt(i).ElementAt(j), p1);
                        if (a1 != a2) // (A,B,D,G,R,F,O,P)
                        {
                            List<int> positionsToDelete = new List<int>();
                            List<string> listToAdd = new List<string>();
                            listToAdd.Add(p1.ElementAt(i).ElementAt(j));
                            positionsToDelete.Add(j);
                            for (int k = j + 1; k < p1.ElementAt(i).Count; k++)
                            {
                                string a3 = getOutputStatesPosition(p1.ElementAt(i).ElementAt(k), p1);
                                if (a2 == a3)
                                {
                                    listToAdd.Add(p1.ElementAt(i).ElementAt(k));
                                    positionsToDelete.Add(k);

                                }
                            }
                            positionsToDelete.Reverse();
                            for (int k = 0; k < positionsToDelete.Count; k++)
                            {
                                p1.ElementAt(i).RemoveAt(positionsToDelete.ElementAt(k));
                            }
                            if (listToAdd.Count > 0)
                            {
                                p1.Add(listToAdd);
                            }
                        }

                    }

                }
            }
            
            return p1;
        }

        //This method returns the group of the state with the name "x" in the list of the partitioning
        public int getGroup(string x, List<List<string>> p1)
        {
            //Position to return
            int positionReturn = -1;

            //This for look into every group of the partitioning
            for(int i = 0; i < p1.Count && positionReturn == -1; i++)
            {
                //This for looks for every state in the group i
                for(int j = 0; j < p1.ElementAt(i).Count && positionReturn == -1; j++)
                {
                    //If "x" is found in the partitioning, the variable turns
                    //into the number of the group and breaks all the for
                    if (x == p1.ElementAt(i).ElementAt(j))
                    {
                        positionReturn = i;
                    }
                }
            }
            return positionReturn;
        }

        /*This method returns the positions of the outputs states
         * 
         *Example: {{A,B,C}{D,E}{F}}, and A,D,0,F,1 ; it gets the outputs states of "A" = "D" and "F"
         *and returns the position of them in the partitioning => "D" = 1, "F" = 2. 
         *and then is joined => "12"
        */
        public string getOutputStatesPosition(string x, List<List<string>> p1)
        {
            //This is the position to return
            string positions = "";

            //Look for each line in the matrix
            for(int i = 0; i < matrix.Count; i++)
            {
                //if the line state name is the same as "x", then...
                if(matrix.ElementAt(i).ElementAt(0) == x)
                {

                    for(int j = 1; j < matrix.ElementAt(i).Count; j+=2)
                    {
                        positions += getGroup(matrix.ElementAt(i).ElementAt(j), p1) + "";
                    }
                }
            }
            return positions;
        }


        //This method joins the redundant states in a single state named by the joing of their names
        //Example: State "A", State "B" => State "AB"
        public void joinElements(List<List<string>> parts)
        {
            //Console.WriteLine("##############" + parts.Count);//7
            string elementChange = "";
            //Estos dos for buscan los elementos a cambiar en la matriz 
            for (int i = 0; i < parts.Count; i++)
            {
                //Console.WriteLine("####################" + i);//0-6
                if (parts.ElementAt(i).Count > 1)
                {
                    for (int j = 0; j < parts.ElementAt(i).Count; j++)
                    {
                        elementChange += parts.ElementAt(i).ElementAt(j);
                    }
                    //En este for hara los cambios de variable en la matriz principal
                    for (int k = 0; k < parts.ElementAt(i).Count; k++)
                    {
                        for (int h = 0; h < matrix.Count; h++)
                        {
                            for (int l = 0; l < matrix.ElementAt(h).Count; l++)
                            {
                                if (matrix.ElementAt(h).ElementAt(l).Equals(parts.ElementAt(i).ElementAt(k)))
                                {
                                    matrix[h][l] = elementChange;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void cleanFinalMatrix()
        {
            for (int h = 0; h < matrix.Count; h++)
            {
                for (int x = h + 1; x < matrix.Count; x++)
                {
                    if (matrix.ElementAt(h).ElementAt(0).Equals(matrix.ElementAt(x).ElementAt(0)))
                    {
                        matrix.RemoveAt(x);
                    }
                }
            }
        }

    }
}

