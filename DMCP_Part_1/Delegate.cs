using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace DMCP_Part_1 {
	class Delegate : ICommand {

		private readonly Action<object> execute;
		public void Execute (object parameter) {
			execute(parameter);
		}

		private readonly Predicate<object> canExecute;
		public bool CanExecute (object parameter) {
			if (canExecute == null) {
				return true;
			}
			return canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged;
		public void RaiseCanExecuteChanged () {
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public Delegate (Action<object> execute) : this(execute, null) { }

		public Delegate (Action<object> execute, Predicate<object> canExecute) {
			this.execute = execute;
			this.canExecute = canExecute;
		}

	}
}
