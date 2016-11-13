using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DMCP_Part_1.Controllers {
	class WindowEnterValuesController : INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged (string propertyChanged) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
		}

		private int providersCount;
		public int ProvidersCount {
			get { return providersCount; }
			set {
				providersCount = value;
				OnPropertyChanged("ProvidersCount");
			}
		}

		private int receiversCount;
		public int ReceiversCount {
			get { return receiversCount; }
			set {
				receiversCount = value;
				OnPropertyChanged("ProvidersCount");
			}
		}

		private List<int> providers;
		public List<int> Providers {
			get { return providers; }
			set {
				providers = value;
				OnPropertyChanged("Providers");
			}
		}

		private List<int> receivers;
		public List<int> Receivers {
			get { return receivers; }
			set {
				receivers = value;
				OnPropertyChanged("Receivers");
			}
		}

		private Delegate createLists_delegate;
		public Delegate CreateLists_delegate {
			get { return createLists_delegate ?? (createLists_delegate = new Delegate(CreateLists)); }
		}
		public void CreateLists (object args) {
			Providers = new List<int>();
			for (int i = 0; i < ProvidersCount; i++)
				Providers.Add(i);

			Receivers = new List<int>();
			for (int i = 0; i < ReceiversCount; i++)
				Receivers.Add(i);
		}
	}
}
