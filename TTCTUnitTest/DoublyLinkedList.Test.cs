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
        [TestInitialize]
        public void Initialize()
        {
            _dll = new DoublyLinkedList();
        }

        //Helper function to store items in the dll
        private void insertItemsToTail(int amount)
        {
            //Get the current size of the dll
            int curr_size = _dll.size();

            for(int i = curr_size; i < amount + curr_size; i++)
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
            int dllSize = 3;

            //Add n items to dll
            insertItemsToTail(dllSize);
            Assert.AreEqual(dllSize, _dll.size());

            //Add n more items to dll
            insertItemsToTail(dllSize);
            Assert.AreEqual((2 * dllSize), _dll.size());

            //Remove all and assert size is 0
            removeAll();
            Assert.AreEqual(0, _dll.size());
        }
        
        [TestMethod]
        public void dllSizeUpdates()
        {
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
        public void dllRemoveFromEmptyList()
        {
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
            string term = "A_TEST_TERM";

            //Add the term and ensure it is contained in dll
            _dll.pushHead(term);
            Assert.IsTrue(_dll.contains(term));

            //Make sure contains matches whole strings
            Assert.IsFalse(_dll.contains(term.Remove(0, 3)));
            Assert.IsFalse(_dll.contains(term + "1"));
        }

        [TestMethod]
        public void dllRemoveNonexistant()
        {
            string badTerm = "NOT_IN_DLL";

            //Insert items and ensure the dll doesn't contain the bad term
            insertItemsToTail(3);
            Assert.IsFalse(_dll.contains(badTerm));

            //Get dll size
            int dllSize = _dll.size();

            //Try remove the bad term
            _dll.remove(badTerm);

            //Assert size hasn't changed
            Assert.AreEqual(dllSize, _dll.size());
        }

        [TestMethod]
        public void dllRemoveFromHead()
        {
            string term = "DLL_TERM";

            //Insert items
            insertItemsToTail(3);

            //Ensure the dll doesn't contain the term, add it, then ensure it is contained
            Assert.IsFalse(_dll.contains(term));
            _dll.pushHead(term);
            Assert.IsTrue(_dll.contains(term));

            //Get dll size
            int dllSize = _dll.size();

            //Remove the term, make sure it is no longer in the dll
            _dll.remove(term);
            Assert.IsFalse(_dll.contains(term));

            //Assert size has been updated
            Assert.AreEqual(dllSize - 1, _dll.size());
        }

        [TestMethod]
        public void dllRemoveFromTail()
        {
            string term = "DLL_TERM";

            //Insert items
            insertItemsToTail(3);

            //Ensure the dll doesn't contain the term, add it, then ensure it is contained
            Assert.IsFalse(_dll.contains(term));
            _dll.pushTail(term);
            Assert.IsTrue(_dll.contains(term));

            //Get dll size
            int dllSize = _dll.size();

            //Remove the term, make sure it is no longer in the dll
            _dll.remove(term);
            Assert.IsFalse(_dll.contains(term));

            //Assert size has been updated
            Assert.AreEqual(dllSize - 1, _dll.size());
        }

        [TestMethod]
        public void dllRemoveFromMiddle()
        {
            string term = "DLL_TERM";

            //Insert items
            insertItemsToTail(3);

            //Ensure the dll doesn't contain the term, add it, then ensure it is contained
            Assert.IsFalse(_dll.contains(term));
            _dll.pushTail(term);
            Assert.IsTrue(_dll.contains(term));

            //Add more items to ensure the term will be removed from the middle
            insertItemsToTail(3);

            //Get dll size
            int dllSize = _dll.size();

            //Remove the term, make sure it is no longer in the dll
            _dll.remove(term);
            Assert.IsFalse(_dll.contains(term));

            //Assert size has been updated
            Assert.AreEqual(dllSize - 1, _dll.size());
        }

        [TestMethod]
        public void dllgetAllTerms()
        {
            string[] terms = { "A", "B", "C", "D" };

            //Ensure the dll is empty
            Assert.IsTrue(_dll.isEmpty());

            //Add all terms
            foreach(string term in terms)
            {
                _dll.pushHead(term);
            }

            string allDllTerms = _dll.getAllTerms();

            foreach(string term in terms)
            {
                //Assert that the term is contained in the dll
                Assert.IsTrue(_dll.contains(term));
                //Assert that the term is contained in the output string of the dll
                Assert.IsTrue(allDllTerms.Contains(term));
            }
        }

        [TestMethod]
        public void dllgetAllTermsEmpty()
        {
            string[] terms = { "A", "B", "C", "D" };

            //Ensure the dll is empty
            Assert.IsTrue(_dll.isEmpty());

            //Add all terms
            foreach(string term in terms)
            {
                _dll.pushHead(term);
            }

            int dllSize = _dll.size();

            //Assert that the size of the terms array and the dll match
            Assert.AreEqual(terms.Length, dllSize);

            //Remove all items and assert that the dll is empty
            removeAll();
            Assert.IsTrue(_dll.isEmpty());
            
            //Get all the terms
            string allDllTerms = _dll.getAllTerms();

            foreach(string term in terms)
            {
                //Assert that the term is not contained in the dll
                Assert.IsFalse(_dll.contains(term));
                //Assert that the term is not contained in the output string of the dll
                Assert.IsFalse(allDllTerms.Contains(term));
            }
        }
    }
}
