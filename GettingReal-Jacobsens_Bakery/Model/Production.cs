using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Production
    {
		public ProdItem Item = new ProdItem();
		private DateTime _prodStart;

		public DateTime ProdStart
		{
			get { return _prodStart; }
			set { _prodStart = DateTime.Now; }
		}
		private DateTime _prodEnd;

		public DateTime ProdEnd
		{
			get { return _prodEnd; }
			set { _prodEnd = DateTime.Now; }
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
