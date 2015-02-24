using System.Windows.Input;

namespace PowerSmell.Core.Entry.Handlers.Base
{
    public abstract class AbstractKeyHandler : IKeyHandler
    {
        public virtual void Handle(KeyEventArgs e)
        {
            if (!ShouldExecute(e)) return;
            HandleCore(e);
            if (ShouldMarkHandled(e))
                e.Handled = true;
        }

        protected abstract void HandleCore(KeyEventArgs e);
        protected abstract bool ShouldExecute(KeyEventArgs e);

        protected virtual bool ShouldMarkHandled(KeyEventArgs e)
        {
            return true;
        }
    }
}
