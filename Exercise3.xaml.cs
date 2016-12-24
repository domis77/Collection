using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.Diagnostics;

namespace Collection
{
    /// <summary>
    /// Interaction logic for Exercise3.xaml
    /// </summary>
    public partial class Exercise3 : Window
    {
        public Exercise3()
        {
            InitializeComponent();

            checkPerformanceArrayList();
            checkPerformanceLinkedList();
        }

        private void runAl_button0_Click(object sender, RoutedEventArgs e)
        {
            checkPerformanceArrayList();
        }

        private void runLl_button0_Click(object sender, RoutedEventArgs e)
        {
            checkPerformanceLinkedList();
        }

        public void checkPerformanceArrayList()
        {
            int numberOfElementsAl;
            int.TryParse(numberOfElementsAl_textBox0.Text, out numberOfElementsAl);

            TestArrayList testArrayList = new TestArrayList();
            testArrayList.fillListRandomObjects(numberOfElementsAl);

            testArrayList.getdElementPrepend(beginMsGetAl_textBlock0);
            testArrayList.getElementMiddle(middleMsGetAl_textBlock0);
            testArrayList.getElementEnd(endMsGetAl_textBlock0);

            testArrayList.addElementPrepend(beginMsAddAl_textBlock0);
            testArrayList.addElementMiddle(middleMsAddAl_textBlock0);
            testArrayList.addElementEnd(endMsAddAl_textBlock0);

            testArrayList.deleteElementPrepend(beginMsDelAl_textBlock0);
            testArrayList.deleteElementMiddle(middleMsDelAl_textBlock0);
            testArrayList.deleteElementEnd(endMsDelAl_textBlock0);
        }


        public void checkPerformanceLinkedList()
        {
            int numberOfElementsLl;
            int.TryParse(numberOfElementsLl_textBox0.Text, out numberOfElementsLl);

            TestLinkedList testLinkedList = new TestLinkedList();
            testLinkedList.fillListRandomObjects(numberOfElementsLl);

            testLinkedList.getdElementPrepend(beginMsGetLl_textBlock0);
            testLinkedList.getElementMiddle(middleMsGetLl_textBlock0);
            testLinkedList.getElementEnd(endMsGetLl_textBlock0);

            testLinkedList.addElementPrepend(beginMsAddLl_textBlock0);
            testLinkedList.addElementMiddle(middleMsAddLl_textBlock0);
            testLinkedList.addElementEnd(endMsAddLl_textBlock0);

            testLinkedList.deleteElementPrepend(beginMsDelLl_textBlock0);
            testLinkedList.deleteElementMiddle(middleMsDelLl_textBlock0);
            testLinkedList.deleteElementEnd(endMsDelLl_textBlock0);
        }

        
    }



    public class TestObject
    {
        private int randomNumber;

        public TestObject( int randomNumber)
        {
            this.randomNumber = randomNumber;
        }

        public int getValue()
        {
            return randomNumber;
        }
    }


    public class TestArrayList
    {
        private ArrayList arrayList;
        private Random rand;

        public TestArrayList()
        {
            arrayList = new ArrayList();
            rand = new Random();
        }

        public void fillListRandomObjects( int initialElements )
        {
            for(var i = 0; i < initialElements; i++)
            {
                arrayList.Add(new TestObject(rand.Next(10)));
            }
        }


        private object getdElementPrepend()
        {
            return arrayList[0];
        }
        public void getdElementPrepend( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getdElementPrepend();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        private object getElementMiddle()
        {
            return arrayList[arrayList.Count / 2];
        }
        public void getElementMiddle( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getElementMiddle();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        private object getElementEnd()
        {
            return arrayList[arrayList.Count - 1];
        }
        public void getElementEnd( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getElementEnd();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }


        public void addElementPrepend( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                arrayList.Insert(0, obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void addElementMiddle( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));
            var executionTime = Stopwatch.StartNew();
                arrayList.Insert(arrayList.Count / 2, obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void addElementEnd( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                arrayList.Add(obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }


        public void deleteElementPrepend( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                arrayList.RemoveAt(0);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void deleteElementMiddle( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                arrayList.RemoveAt(arrayList.Count / 2);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();      
        }

        public void deleteElementEnd( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                arrayList.RemoveAt(arrayList.Count-1);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }
    }


    public class TestLinkedList
    {
        LinkedList<TestObject> linkedList;
        private Random rand;

        public TestLinkedList()
        {
            linkedList = new LinkedList<TestObject>();
            rand = new Random();
        }

        public void fillListRandomObjects(int initialElements)
        {
            for (var i = 0; i < initialElements; i++)
            {
                linkedList.AddFirst(new TestObject(rand.Next(10)));
            }
        }

        private LinkedListNode<TestObject> getMiddleNode()
        {
            LinkedListNode<TestObject> middleNode = null;
            IEnumerator<TestObject> enumerator = linkedList.GetEnumerator();

            var i = 0;
            while (enumerator.MoveNext())
            {
                if (i == linkedList.Count / 2)
                {
                    middleNode = linkedList.Find(enumerator.Current);
                    break;
                }
                i++;
            }
            return middleNode;
        }


        private object getdElementPrepend()
        {
            return linkedList.First;
        }
        public void getdElementPrepend( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getdElementPrepend();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        private object getElementMiddle()
        {
            return getMiddleNode();
        }
        public void getElementMiddle( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getElementMiddle();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        private object getElementEnd()
        {
            return linkedList.Last;
        }
        public void getElementEnd( TextBlock displayExecTime )
        {
            var executionTime = Stopwatch.StartNew();
                getElementEnd();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }


        public void addElementPrepend( TextBlock displayExecTime )
        {  
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.AddFirst(obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void addElementMiddle( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.AddAfter(getMiddleNode(), obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void addElementEnd( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.AddLast(obj);
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }


        public void deleteElementPrepend( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.RemoveFirst();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }
         
        public void deleteElementMiddle( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.Remove(getMiddleNode());
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

        public void deleteElementEnd( TextBlock displayExecTime )
        {
            TestObject obj = new TestObject(rand.Next(10));

            var executionTime = Stopwatch.StartNew();
                linkedList.RemoveLast();
            executionTime.Stop();

            displayExecTime.Text = executionTime.Elapsed.ToString();
        }

    }
}
