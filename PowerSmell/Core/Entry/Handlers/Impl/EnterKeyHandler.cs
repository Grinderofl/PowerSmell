using System.Windows.Input;
using PowerSmell.Core.Entry.Handlers.Base;

namespace PowerSmell.Core.Entry.Handlers.Impl
{
    public class EnterKeyHandler : AbstractEntryKeyHandler
    {
        public EnterKeyHandler(PowerSmell.Entry entry)
            : base(entry)
        {
        }

        protected override void HandleCore(KeyEventArgs e)
        {
            Entry.Submitted = true;
        }

        protected override bool ShouldExecute(KeyEventArgs e)
        {
            return e.Key == Key.Enter;
        }
    }

}
