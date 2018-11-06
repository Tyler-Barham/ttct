namespace TTCT
{
    public class DoublyLinkedList
    {
        private ListNode head = null;
        private ListNode tail = null;
        private int item_count = 0;

        //Constuctor
        public DoublyLinkedList()
        {

        }

        //Constructor
        public DoublyLinkedList(string term)
        {
            head = new ListNode(term);
            tail = head;
            item_count = 1;
        }

        //Add to the head
        public void pushHead(string term)
        {
            if(isEmpty())
            {
                head = new ListNode(term);
                tail = head;
            }
            else
            {
                ListNode node = new ListNode(term);

                head.setPrev(node);
                node.setNext(head);
                head = node;
            }
            item_count++;
        }

        //Remove the head
        public void popHead()
        {
            if(head != tail)
            {
                head = head.getNext();
                head.setPrev(null);
                item_count--;
            }
            else
            {
                head = null;
                tail = null;
                item_count = 0;
            }
        }

        //Add to the tail
        public void pushTail(string term)
        {
            if(isEmpty())
            {
                head = new ListNode(term);
                tail = head;
            }
            else
            {
                ListNode node = new ListNode(term);

                tail.setNext(node);
                node.setPrev(tail);
                tail = node;
            }
            item_count++;
        }

        //Remove the tail
        public void popTail()
        {
            if(head != tail)
            {
                tail = tail.getPrevious();
                tail.setNext(null);
                item_count--;
            }
            else
            {
                head = null;
                tail = null;
                item_count = 0;
            }
        }

        //Remove a node that is not head or tail
        //Contains no error checking, use carefully (E.g. in the remove function)
        private void popMiddle(ListNode node)
        {
            node.getNext().setPrev(node.getPrevious());
            node.getPrevious().setNext(node.getNext());
            item_count--;
        }

        //Returns the node with the given term
        private ListNode find(string term)
        {
            ListNode tmp = head;

            while(tmp != null)
            {
                if(tmp.getTerm().Equals(term))
                {
                    return tmp;
                }
                tmp = tmp.getNext();
            }

            return null;
        }

        //Returns whether or not the list contains the string
        public bool contains(string term)
        {
            bool isFound = false;

            if(!isEmpty())
            {
                ListNode tmp = find(term);
                if(tmp != null)
                {
                    isFound = true;
                }
            }

            return isFound;
        }

        //Remove the given term from the list
        public void remove(string term)
        {
            ListNode tmp = find(term);

            if(tmp != null)
            {
                if(tmp == head)
                {
                    popHead();
                }
                else if(tmp == tail)
                {
                    popTail();
                }
                else
                {
                    popMiddle(tmp);
                }
            }
        }

        //Returns whether or not the dll is empty
        public bool isEmpty()
        {
            return(head == null && tail == null);
        }

        //Returns the size of the dll
        public int size()
        {
            return item_count;
        }

        //Returns a string of all terms from head to tail
        public string getAllTerms()
        {
            string terms = "";

            ListNode tmp = head;

            while(tmp != null)
            {
                terms += tmp.getTerm() + " ";
                tmp = tmp.getNext();
            }

            return terms;
        }
    }
}