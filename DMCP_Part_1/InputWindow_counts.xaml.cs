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
	/// Логика взаимодействия для InputWindow.xaml
	/// </summary>
	public partial class InputWindow_counts : Window {

		private readonly InputController controller;

		public InputWindow_counts () {
			InitializeComponent();
			controller = new InputController();
			DataContext = controller;
		}
	}
}
