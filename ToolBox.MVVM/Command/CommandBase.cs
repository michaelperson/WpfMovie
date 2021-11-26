using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ToolBox.MVVM.Command
{
    public class CommandBase : ICommand
    {
        #region Variables
        //Basé sur le délégué "public delegate void Action()"
        private readonly Action _Execute;
        //Basé sur le délégué "public delegate TResult Func<out TResult>()"
        private readonly Func<bool> _CanExecute;        
        #endregion
        #region Constructeurs        
        //Certaines commandes peuvent s'exécuter tout le temps.
        public CommandBase(Action Execute)
            : this(Execute, null)
        { }

        public CommandBase(Action Execute, Func<bool> CanExecute)
        {
            //Si l'action à réaliser est null, je retourne une exception
            if (Execute == null)
                throw new ArgumentNullException("Execute");

            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public event EventHandler CanExecuteChanged;
        #endregion
        #region Implémentation de ICommand


        //Définit la méthode qui détermine si la commande peut s'exécuter dans son état actuel.
        public bool CanExecute(object parameter)
        {
            return (_CanExecute == null) ? true : _CanExecute(); //ou _CanExecute.Invoke();
        }

        //Définit la méthode à appeler lorsque la commande est appelée.
        public void Execute(object parameter)
        {
            _Execute(); // ou _Execute.Invoke();
        }
        #endregion
    }
}
