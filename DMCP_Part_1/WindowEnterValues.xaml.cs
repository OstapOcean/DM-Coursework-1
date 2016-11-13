using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using DMCP_Part_1.Controllers;

namespace DMCP_Part_1 {
	/// <summary>
	/// Логика взаимодействия для WindowEnterValues.xaml
	/// </summary>
	public partial class WindowEnterValues : Window {
		private readonly WindowEnterValuesController controller;

		public WindowEnterValues () {
			InitializeComponent();
			controller = new WindowEnterValuesController();
			DataContext = controller;
		}
	}
}
