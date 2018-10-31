using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTCT;

namespace TTCTUnitTest
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        DoublyLinkedList _dll;

        //Constrictor
        public DoublyLinkedListTest()
        {
            _dll = new DoublyLinkedList();
        }

        //Method to call at the start of each test. Ensures that _dll is clean
        private void setup()
        {
            _dll = new DoublyLinkedList();
        }

        //Helper function to store items in the dll
        private void insertItems(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                _dll.pushTail(i.ToString());
            }
        }

        //Helper function to remove all items from the dll
        private void removeAll()
        {
            while(!_dll.isEmpty())
            {
                _dll.popTail();
            }
        }

        [TestMethod]
        public void testLocalHelperFunctions()
        {
            setup();
            int dllSize = 3;

            //Add n items to dll
            insertItems(dllSize);
            Assert.AreEqual(dllSize, _dll.size());

            //Add n more items to dll
            insertItems(dllSize);
            Assert.AreEqual((2 * dllSize), _dll.size());

            //Remove all and assert size is 0
            removeAll();
            Assert.AreEqual(0, _dll.size());
        }
        
        [TestMethod]
        public void testSizeUpdates()
        {   
            setup();

            //Ensure initial size
            Assert.AreEqual(0, _dll.size());
            
            //Add 1 item to dll through head, and 1 through tail
            _dll.pushHead("a");
            Assert.AreEqual(1, _dll.size());
            _dll.pushTail("b");
            Assert.AreEqual(2, _dll.size());

            _dll.popHead();
            Assert.AreEqual(1, _dll.size());
            _dll.popTail();
            Assert.AreEqual(0, _dll.size());
        }

        [TestMethod]
        public void removeFromEmptyDll()
        {
            setup();

            //Ensure initial size
            Assert.IsTrue(_dll.isEmpty());
            Assert.AreEqual(0, _dll.size());

            //Ensure popHead on empty dll keeps accurate size
            _dll.popHead();
            Assert.AreEqual(0, _dll.size());

            //Ensure popTail on empty dll keeps accurate size
            _dll.popTail();
            Assert.AreEqual(0, _dll.size());
        }

        [TestMethod]
        public void dllContains()
        {
            setup();

            string term = "A_TEST_TERM";

            //Add the term and ensure it is contained in dll
            _dll.pushHead(term);
            Assert.IsTrue(_dll.contains(term));

            //Make sure contains matches whole strings
            Assert.IsFalse(_dll.contains(term.Remove(0, 3)));
            Assert.IsFalse(_dll.contains(term + "1"));
        }

        //_dll.remove(term);
        //_dll.getAllTerms();
    }
}
