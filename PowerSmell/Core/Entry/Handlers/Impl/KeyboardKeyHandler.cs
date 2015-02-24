using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PowerSmell.Core.Entry.Handlers.Base;
using PowerSmell.Core.Input.Extensions;

namespace PowerSmell.Core.Entry.Handlers.Impl
{
    public class KeyboardKeyHandler : AbstractEntryKeyHandler
    {
        public KeyboardKeyHandler(PowerSmell.Entry entry) : base(entry)
        {
        }

        protected override void HandleCore(KeyEventArgs e)
        {
            string key = "";
            if (_numericKeys.FirstOrDefault(x => x == e.Key) != Key.None)
                key = e.Key.ToString().Substring(1);
            else if (e.Key == Key.Space)
                key = " ";
            else
                key = e.Key.ToProperCaseString();

            Entry.Append(key);
        }

        private readonly List<Key> _numericKeys = new List<Key>()
        {
            Key.D0,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
        }; 

        protected override bool ShouldExecute(KeyEventArgs e)
        {
            return true;
        }
    }
}
