namespace TTCT
{
    class ListNode
    {
        private string term = "";
        private ListNode next = null;
        private ListNode prev = null;

        //Constructor
        public ListNode()
        {

        }

        //Constructor
        public ListNode(string term)
        {
            this.term = term;
        }

        //Getters/Setters
        
        public string getTerm()
        {
            return term;
        }

        public void setTerm(string term)
        {
            this.term = term;
        }

        public ListNode getNext()
        {
            return next;
        }

        public void setNext(ListNode next)
        {
            this.next = next;
        }

        public ListNode getPrevious()
        {
            return prev;
        }

        public void setPrev(ListNode prev)
        {
            this.prev = prev;
        }
    }
}