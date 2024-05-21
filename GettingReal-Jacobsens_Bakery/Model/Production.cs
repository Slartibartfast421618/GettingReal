namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Production
    {
        public Item ProdItem = new Item();
        private DateTime _prodStart;
        private DateTime _prodEnd;
        private string _prodOrderId;
        private int _boxesProduced;

        public DateTime ProdStart
        {
            get { return _prodStart; }
            set { _prodStart = value; }
        }

        public DateTime ProdEnd
        {
            get { return _prodEnd; }
            set { _prodEnd = value; }
        }

        public string ProdOrderId
        {
            get { return _prodOrderId; }
            set { _prodOrderId = value; }
        }

        public int BoxesProduced
        {
            get { return _boxesProduced; }
            set { _boxesProduced = value; }
        }

    }
}
