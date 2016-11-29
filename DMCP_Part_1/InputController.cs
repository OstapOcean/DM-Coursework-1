using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace DMCP_Part_1 {

	public class IntView : InputController {
		private int intValue;
		public int IntValue {
			get { return intValue; }
			set {
				intValue = value;
				OnPropertyChanged("IntValue");
			}
		}

		public static int[] ToIntArray (ObservableCollection<IntView> collection) {
			int[] array = new int[collection.Count];

			for (int i = 0; i < collection.Count; i++)
				array[i] = collection[i].IntValue;

			return array;
		}
	}

	public class InputController : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged (string propertyChanged) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
		}

		#region Properties

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

		private ObservableCollection<IntView> providerCapacity;
		public ObservableCollection<IntView> ProvidersCapacity {
			get { return providerCapacity; }
			set {
				providerCapacity = value;
				OnPropertyChanged("ProvidersCapacity");
			}
		}

		private ObservableCollection<IntView> receiversCapacity;
		public ObservableCollection<IntView> ReceiversCapacity {
			get { return receiversCapacity; }
			set {
				receiversCapacity = value;
				OnPropertyChanged("ReceiversCapacity");
			}
		}

		private int[][] costTable;
		public int[][] CostTable {
			get { return costTable; }
			set {
				costTable = value;
				OnPropertyChanged("CostTable");
			}
		}

		private int[][] costMatrix;
		public int[][] CostMatrix {
			get { return costMatrix; }
			set {
				costMatrix = value;
				OnPropertyChanged("CostMatrix");
			}
		}

		private int[][] capacityMatrix;
		public int[][] CapacityMatrix {
			get { return capacityMatrix; }
			set {
				capacityMatrix = value;
				OnPropertyChanged("CapacityMatrix");
			}
		}

		private DataTable costTable_dataTable;
		public DataTable CostTable_dataTable {
			get {
				return costTable_dataTable;
			}
			set {
				costTable_dataTable = value;
				OnPropertyChanged("CostMatrix_dataTable");
			}
		}

		#endregion Properties

		#region PublicMethods

		private Delegate createInputContainers_delegate;
		public Delegate CreateInputContainers_delegate {
			get { return createInputContainers_delegate ?? (createInputContainers_delegate = new Delegate(CreateInputContainers)); }
		}
		public void CreateInputContainers (object args) {

			ProvidersCapacity = CreateList(ProvidersCapacity, ProvidersCount);
			ReceiversCapacity = CreateList(ReceiversCapacity, ReceiversCount);
			CreateCostTable_dataTable(ReceiversCount, ProvidersCount);

			new InputWindow(this).ShowDialog();
		}

		private Delegate createMatrices_delegate;
		public Delegate CreateMatrices_delegate {
			get { return createMatrices_delegate ?? (createMatrices_delegate = new Delegate(CreateMatrices)); }
		}
		public void CreateMatrices (object args) {
			CostTable = new int[ProvidersCount][];
			for (int i = 0; i < ProvidersCount; i++)
				CostTable[i] = new int[ReceiversCount];

			for (int i = 0; i < ProvidersCount; i++)
				for (int j = 0; j < ReceiversCount; j++)
					CostTable[i][j] = Int32.Parse(CostTable_dataTable.Rows[i][j].ToString());

			CreateCapacityMatrix();
			CreateCostMatrix();

			//Application.Current.Windows[2].Close();
			new OutputWindow(costMatrix, capacityMatrix).ShowDialog();
			//new OutputWindow().ShowDialog();
		}

		#endregion PublicMethods

		private ObservableCollection<IntView> CreateList (ObservableCollection<IntView> list, int listSize) {
			list = new ObservableCollection<IntView>();
			for (int i = 0; i < listSize; i++)
				list.Add(new IntView());

			return list;
		}

		private void CreateCostTable_dataTable (int columnCount, int rowsCount) {
			CostTable_dataTable = new DataTable();

			for (int i = 0; i < columnCount; i++)
				CostTable_dataTable.Columns.Add(new DataColumn(i.ToString()));

			DataRow[] array = new DataRow[columnCount];

			for (int i = 0; i < rowsCount; i++)
				CostTable_dataTable.Rows.Add(array);
		}

		private void CreateCapacityMatrix () {
			int matrixSize = (ProvidersCount + ReceiversCount + 2);

			CapacityMatrix = InitializeMatrix(CapacityMatrix, matrixSize, 0);

			for (int i = 0; i < ProvidersCount; i++)
				CapacityMatrix[0][i + 1] = ProvidersCapacity[i].IntValue;

			for (int i = 0; i < ReceiversCount; i++)
				CapacityMatrix[i + ProvidersCount + 1][matrixSize - 1] = ReceiversCapacity[i].IntValue;

			for (int i = 0; i < ProvidersCount; i++)
				for (int j = 0; j < ReceiversCount; j++)
					CapacityMatrix[i + 1][ProvidersCount + 1 + j] = 9999;
		}

		private void CreateCostMatrix () {
			int matrixSize = (ProvidersCount + ReceiversCount + 2);

			CostMatrix = InitializeMatrix(CostMatrix, matrixSize, 9999);

			for (int i = 0; i < ProvidersCount; i++)
				CostMatrix[0][i + 1] = 0;

			for (int i = 0; i < ReceiversCount; i++)
				CostMatrix[i + ProvidersCount + 1][matrixSize - 1] = 0;

			for (int i = 0; i < ProvidersCount; i++)
				for (int j = 0; j < ReceiversCount; j++)
					CostMatrix[i + 1][ProvidersCount + 1 + j] = CostTable[i][j];
		}

		private int[][] InitializeMatrix (int[][] matrix, int matrixSize, int initValue) {
			matrix = new int[matrixSize][];
			for (int i = 0; i < matrixSize; i++)
				matrix[i] = new int[matrixSize];

			for (int i = 0; i < matrixSize; i++)
				for (int j = 0; j < matrixSize; j++)
					matrix[i][j] = initValue;

			return matrix;
		}
	}
}
