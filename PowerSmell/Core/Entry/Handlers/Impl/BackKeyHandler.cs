using System.Windows.Input;
using PowerSmell.Core.Entry.Handlers.Base;

namespace PowerSmell.Core.Entry.Handlers.Impl
{
    public class BackKeyHandler : AbstractEntryKeyHandler
    {
        protected override void HandleCore(KeyEventArgs e)
        {
            Entry.Trim();
        }

        protected override bool ShouldExecute(KeyEventArgs e)
        {
            return e.Key == Key.Back;
        }

        public BackKeyHandler(PowerSmell.Entry entry)
            : base(entry)
        {
        }
    }
}