using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PowerSmell.Core.Entry.Handlers.Base;

namespace PowerSmell.Core.Entry.Handlers.Impl
{
    public class PasteKeyHandler : AbstractEntryKeyHandler
    {
        public PasteKeyHandler(PowerSmell.Entry entry) : base(entry)
        {
        }

        protected override void HandleCore(KeyEventArgs e)
        {
            Entry.Append(Clipboard.GetText());
        }

        protected override bool ShouldExecute(KeyEventArgs e)
        {
            return Keyboard.GetKeyStates(Key.LeftCtrl) == KeyStates.Down;
        }
    }
}
