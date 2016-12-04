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

		private List<int> deltaF;
		public int DeltaFlow {
			get { return deltaF[listIndex]; }
		}
		private List<int> currentFlow;
		public int CurrentFlow { get { return currentFlow[listIndex]; } }

		private int listIndex = 0;
		public int CurrentIteration {
			get { return listIndex; }
		}
		public string CurrentIterationOutput {
			get {
				return "Шаг " + CurrentIteration + " из " + (currentFlow.Count - 1);
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

			flowGraphraphList = new List<TransportGraph>();
			incrementalGraphraphList = new List<TransportGraph>();
			//int q = 9999;
			//int[][] costMatrix = {
			//			 new int[]{q,0,0,0,q,q,q,q,q},
			//			 new int[]{q,q,q,q,10,11,18,32,q},
			//			 new int[]{q,q,q,q,16,14,20,25,q},
			//			 new int[]{q,q,q,q,26,28,22,30,q},
			//			 new int[]{q,q,q,q,q,q,q,q,0},
			//			 new int[]{q,q,q,q,q,q,q,q,0},
			//			 new int[]{q,q,q,q,q,q,q,q,0},
			//			 new int[]{q,q,q,q,q,q,q,q,0},
			//			 new int[]{q,q,q,q,q,q,q,q,q}
			//};
			//int[][] capacityMatrix = {
			//			 new int[]{0,41,50,89,0,0,0,0,0},
			//			 new int[]{0,0,0,0,q,q,q,q,0},
			//			 new int[]{0,0,0,0,q,q,q,q,0},
			//			 new int[]{0,0,0,0,q,q,q,q,0},
			//			 new int[]{0,0,0,0,0,0,0,0,44},
			//			 new int[]{0,0,0,0,0,0,0,0,33},
			//			 new int[]{0,0,0,0,0,0,0,0,71},
			//			 new int[]{0,0,0,0,0,0,0,0,10},
			//			 new int[]{0,0,0,0,0,0,0,0,0}
			//};
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
			network.IntermediateTransportNetResult += new IntermediateGraphDelegate(Catcher);
			network.FlowMinCost(searchFlow);
		}

		private void Catcher(object sender, IntermediateTransportNetEventArgs args) {
			flowGraphraphList.Add(args.FlowGraph);
			incrementalGraphraphList.Add(args.IncrementalGraph);
			deltaF.Add(args.deltaF);
			currentFlow.Add(args.currentFlow);
		}


		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyChanged) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
		}
	}
}