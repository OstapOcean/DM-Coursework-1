using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using QuickGraph;
using GraphX.PCL.Logic.Models;


namespace DMCP_Part_1 {

	class Visualizer : INotifyPropertyChanged {
		private TransportNetwork network;
 
        private List<List<int>> ways;
        public List<int> CurrentWay
        {
            get { return ways[listIndex]; }
        }
		private List<int> deltaF;
		public int DeltaFlow {
			get { return deltaF[listIndex]; }
		}
		private List<int> currentFlow;
		public int CurrentFlow { get { return currentFlow[listIndex]; } }
		public int CurrentFlowCount { get { return currentFlow.Count; } }

		private int listIndex = 0;
		public int CurrentIteration {
			get { return listIndex; }
		}
		public string CurrentIterationOutput {
			get {
				return "Шаг " + (CurrentIteration + 1) + " из " + currentFlow.Count;
			}
		}


		private List<TransportGraph> incrementalGraphraphList;
		public TransportGraph IncrementalGraphToShow {
			get {
				return incrementalGraphraphList[listIndex];
			}
		}

		private List<TransportGraph> flowGraphraphList;
		public TransportGraph FlowGraphToShow {
			get {
				return flowGraphraphList[listIndex];
			}
		}

        private int finalCost;
        public int FinalCost { get { return finalCost; } }

		public void GoToLastIndex() {
			listIndex = flowGraphraphList.Count - 1;
			OnPropertyChanged("DeltaFlow");
			OnPropertyChanged("CurrentFlow");
			OnPropertyChanged("CurrentIteration");

			OnPropertyChanged("CurrentIterationOutput");
		}
		public void IncGraphListIndex() {
			if (listIndex + 1 < flowGraphraphList.Count) {
				listIndex = listIndex + 1;
				OnPropertyChanged("DeltaFlow");
				OnPropertyChanged("CurrentFlow");
				OnPropertyChanged("CurrentIteration");

				OnPropertyChanged("CurrentIterationOutput");
			}
		}
		public void DecGgraphListIndex() {
			if (listIndex - 1 >= 0) {
				listIndex = listIndex - 1;
				OnPropertyChanged("DeltaFlow");
				OnPropertyChanged("CurrentFlow");
				OnPropertyChanged("CurrentIteration");

				OnPropertyChanged("CurrentIterationOutput");
			}
		}

		public Visualizer(int[][] costMatrix, int[][] capacityMatrix) {
			deltaF = new List<int>();
			currentFlow = new List<int>();
            ways = new List<List<int>>();
			flowGraphraphList = new List<TransportGraph>();
			incrementalGraphraphList = new List<TransportGraph>();
		
			int maxProvidersFlow = 0;
			for (int i = 0; i < capacityMatrix.Length; ++i) {
				maxProvidersFlow += capacityMatrix[0][i];
			}
			int maxConsumersFlow = 0;
			for (int i = 0; i < capacityMatrix[0].Length; ++i) {
				maxConsumersFlow += capacityMatrix[i][capacityMatrix[0].Length - 1];
			}
			int searchFlow = maxProvidersFlow > maxConsumersFlow ? maxConsumersFlow : maxProvidersFlow;
			network = new TransportNetwork(capacityMatrix, costMatrix);
			network.IntermediateTransportNetResult += new IntermediateGraphDelegate(ArgsCatcher);
			network.FlowMinCost(searchFlow);
		}

       
		private void ArgsCatcher(object sender, IntermediateTransportNetEventArgs args) {
			flowGraphraphList.Add(args.FlowGraph);
			incrementalGraphraphList.Add(args.IncrementalGraph);
			deltaF.Add(args.deltaF);
			currentFlow.Add(args.currentFlow);
            finalCost = args.cost;
            ways.Add(args.Way);
		}

        public void LabelSwitcher()
        {
            GEdge.includeCost = !GEdge.includeCost;

            OnPropertyChanged("DeltaFlow");
            OnPropertyChanged("CurrentFlow");
            OnPropertyChanged("CurrentIteration");

            OnPropertyChanged("CurrentIterationOutput");
        }

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyChanged) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
		}
	}
}