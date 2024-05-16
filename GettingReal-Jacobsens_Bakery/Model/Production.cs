using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Production
    {
        public Item ProdItem = new Item();
        private DateTime _prodStart;

        public DateTime ProdStart
        {
            get { return _prodStart; }
            set { _prodStart = value; }
        }
        private DateTime _prodEnd;

        public DateTime ProdEnd
        {
            get { return _prodEnd; }
            set { _prodEnd = value; }
        }
        private string _prodOrderId;

        public string ProdOrderId
        {
            get { return _prodOrderId; }
            set { _prodOrderId = value; }
        }
        private int _boxesProduced;

        public int BoxesProduced
        {
            get { return _boxesProduced; }
            set { _boxesProduced = value; }
        }

    }
}
