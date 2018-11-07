using System;
using System.Collections;

namespace Structures
{
    class TestStructure
    {
        private static int numberOfTests = 100;
        private static int testedCount = 100000;
        private static int testedInterval = 1000;
        private static int count = 0;

        private static AvlTree<int, int> tree = new AvlTree<int, int>();

        static void Main(string[] args)
        {
            for (int j = 0; j < numberOfTests; j++)
            {
                tree = new AvlTree<int, int>();
                Random randomKey = new Random(j);
                Random randomOperation = new Random(j);
                Random randomDeleted = new Random(j);
                ArrayList elements = new ArrayList();
                var counter = 0;

                for (int i = 0; i < testedCount; i++)
                {
                    var key = randomKey.Next(0, 1000000);
                    var operation = randomOperation.NextDouble();
                    counter++;
                    if (operation < 0.5)
                    {
                        if (tree.Insert(key, key))
                        {
                            elements.Add(key);
                            //Console.WriteLine("insert: " + key);
                        }

                    }
                    else
                    {
                        if (elements.Count != 0)
                        {
                            var deleted = randomDeleted.Next(0, elements.Count);
                            //Console.WriteLine("Deleted: " + (int)elements[deleted]);
                            if (tree.Delete((int)elements[deleted]))
                            {
                                elements.Remove(elements[deleted]);
                            }
                        }
                    }
                    if (counter == testedInterval)
                    {
                        tree.CheckDepth();
                        CheckOrder();
                    }
                }
                Console.WriteLine("Test " + j + ". finished.");
            }

            /*tree = new AvlTree<int, int>();
            for (int i = 0; i < 10; i++)
            {
                tree.Insert(i, i);
            }

            foreach (int cislo in tree.GetLevelEnumerator())
            {
                Console.WriteLine(cislo);
            }*/

            /*Random randomKey = new Random(8);
            Random randomOperation = new Random(8);
            Random randomDeleted = new Random(8);
            ArrayList elements = new ArrayList();
            var key = 0;
            double operation = 0;
            var deleted = 0;
            var counter = 0;

            for (int i = 0; i < testedCount; i++)
            {
                key = randomKey.Next(0, 1000);
                operation = randomOperation.NextDouble();
                counter++;
                if (operation < 0.6)
                {
                    tree.Insert(key, key);
                    elements.Add(key);
                    Console.WriteLine("insert: " + key);
                }
                else
                {
                    if (elements.Count != 0)
                    {
                        deleted = randomDeleted.Next(0, elements.Count);
                        Console.WriteLine("Deleted: " + (int)elements[deleted]);
                        tree.Delete((int)elements[deleted]);
                        elements.Remove(elements[deleted]);
                    }
                }
                    tree.CheckDepth();
                    CheckOrder();
            }*/
            Console.ReadKey();

            /*tree.Insert(516,516);
            tree.Insert(552,552);
            tree.Insert(0,0);
            tree.Delete(552);
            tree.Insert(26,26);
            tree.Insert(571,571);
            tree.Insert(497,497);
            tree.Insert(87,87);
            tree.Delete(571);
            tree.Delete(516);
            tree.Insert(571,571);
            tree.Insert(456,456);
            tree.Insert(374,374);
            tree.Delete(456);
            tree.Insert(115,115);
            tree.Delete(0);
            tree.Delete(571);
            tree.Insert(203,203);
            tree.Insert(49,49);
            tree.Insert(490,490);
            tree.Insert(489,489);
            tree.Delete(115);
            tree.Delete(26);*/

            // to do nahodne vkladanie a nahodne vymazavanie

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(75, 75);
            tree.Delete(150);*/ // test B=1 F=0 lava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(75, 75);
            tree.Insert(25, 25);
            tree.Insert(200, 200);
            tree.Insert(80, 80);
            tree.Delete(200);*/ // test B=1 F=1 lava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(75, 75);
            tree.Insert(25, 25);
            tree.Insert(200, 200);
            tree.Insert(60, 60);
            tree.Delete(200);*/ // test B=1 F=-1 lava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(75, 75);
            tree.Insert(25, 25);
            tree.Delete(150);*/ // test B=0 F=0 lava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(200, 200);
            tree.Insert(125, 125);
            tree.Delete(50);*/ // test B=0 F=0 prava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(125, 125);
            tree.Delete(50);*/ // test B=-1 F=0 prava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(25, 25);
            tree.Insert(125, 125);
            tree.Insert(175, 175);
            tree.Insert(130, 130);
            tree.Delete(25);*/ // test B=-1 F=1 prava

            /*tree.Insert(100,100);
            tree.Insert(50,50);
            tree.Insert(150,150);
            tree.Insert(25, 25);
            tree.Insert(125, 125);
            tree.Insert(175, 175);
            tree.Insert(110, 110);
            tree.Delete(25);*/ // test B=-1 F=-1 prava
        }

        private static void CheckOrder()
        {
            count = 0;
            var predosly = 0;
            foreach (var node in tree)
            {
                if (count > 0)
                {
                    if (node.Key < predosly)
                    {
                        Console.WriteLine("Order of the nodes is wrong.");
                    }
                }
                //Console.WriteLine(node.Key);
                count++;
                predosly = node.Key;
            }
        }
    }
}
