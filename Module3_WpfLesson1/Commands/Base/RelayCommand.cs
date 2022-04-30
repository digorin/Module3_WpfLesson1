﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_WpfLesson1.Commands.Base
{
    internal class RelayCommand: Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute?.Invoke(parameter);


    }

}
