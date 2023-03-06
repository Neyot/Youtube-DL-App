using System;
using System.Windows.Input;

namespace Youtube_DL_App.Mvvm
{
    /// <summary>
    /// WPF MVVM ICommand implementation.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Method to be called when the command is invoked.
        /// </summary>
        private readonly ICommandOnExecute execute;

        /// <summary>
        /// Method that determines whether the command can execute in its current state.
        /// </summary>
        private readonly ICommandOnCanExecute? canExecute;

        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Method to be called when the command is invoked.</param>
        /// <param name="canExecuteMethod">Method that determines whether the command can execute in its current state.</param>
        public RelayCommand(ICommandOnExecute executeMethod, ICommandOnCanExecute canExecuteMethod)
        {
            this.execute = executeMethod;
            this.canExecute = canExecuteMethod;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Method to be called when the command is invoked.</param>
        public RelayCommand(ICommandOnExecute executeMethod)
        {
            this.execute = executeMethod;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked. 
        /// </summary>
        /// <param name="parameter">Delegate context object.</param>
        public delegate void ICommandOnExecute(object? parameter);

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Delegate context object.</param>
        /// <returns><see langword="true"/> if this command can be executed; otherwise, <see langword="false"/>.</returns>
        public delegate bool ICommandOnCanExecute(object? parameter);

        /// <summary>
        /// Event raised when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><see langword="true"/> if this command can be executed; otherwise, <see langword="false"/>.</returns>
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute.Invoke(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked. 
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object? parameter)
        {
            this.execute.Invoke(parameter);
        }
    }
}
