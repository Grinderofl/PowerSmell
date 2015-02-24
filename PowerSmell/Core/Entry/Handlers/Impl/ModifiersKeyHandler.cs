using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PowerSmell.Core.Entry.Handlers.Base;

namespace PowerSmell.Core.Entry.Handlers.Impl
{
    public class ModifiersKeyHandler : AbstractEntryKeyHandler
    {
        public ModifiersKeyHandler(PowerSmell.Entry entry) : base(entry)
        {
        }

        protected override void HandleCore(KeyEventArgs e)
        {
            
        }

        protected override bool ShouldExecute(KeyEventArgs e)
        {
            return Modifiers().Any(x => x == e.Key);
        }

        private IEnumerable<Key> Modifiers()
        {
            yield return Key.CapsLock;
            yield return Key.LeftShift;
            yield return Key.RightShift;
            yield return Key.LeftCtrl;
            yield return Key.RightCtrl;
            yield return Key.LeftAlt;
            yield return Key.RightAlt;
        }
    }
}
