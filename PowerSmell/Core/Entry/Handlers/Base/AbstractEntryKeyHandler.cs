namespace PowerSmell.Core.Entry.Handlers.Base
{
    public abstract class AbstractEntryKeyHandler : AbstractKeyHandler
    {
        protected readonly PowerSmell.Entry Entry;

        protected AbstractEntryKeyHandler(PowerSmell.Entry entry)
        {
            Entry = entry;
        }
    }
}