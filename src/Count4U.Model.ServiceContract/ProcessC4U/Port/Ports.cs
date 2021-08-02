using System;
using System.Collections.ObjectModel;

namespace Count4U.Model.ProcessC4U
{

	public class Ports : ObservableCollection<Port>
    {
		public static Ports FromEnumerable(System.Collections.Generic.IEnumerable<Port> List)
        {
			Ports ports = new Ports();
			foreach (Port item in List)
            {
                ports.Add(item);
            }
            return ports;
        }

		public Port CurrentItem { get; set; }

        public System.EventHandler CurrentChanged { get; set; }

		public long TotalCount { get; set; }
    }
}
