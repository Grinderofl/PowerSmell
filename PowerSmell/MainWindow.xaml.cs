using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PowerSmell.Core.Entry.Handlers;
using PowerSmell.Core.Entry.Handlers.Base;
using PowerSmell.Core.Entry.Handlers.Impl;

namespace PowerSmell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DirectoryInfo _currentDirectory;
        private readonly Entry _entry;
        private readonly IEnumerable<IKeyHandler> _handlers;

        public MainWindow()
        {
            InitializeComponent();
            _currentDirectory = new DirectoryInfo("D:\\");
            _entry = new Entry();
            _handlers = CreateKeyHandlers();
            SetInput();
        }

        private IEnumerable<IKeyHandler> CreateKeyHandlers()
        {
            yield return new ModifiersKeyHandler(_entry);
            yield return new BackKeyHandler(_entry);
            yield return new EnterKeyHandler(_entry);
            yield return new PasteKeyHandler(_entry);
            yield return new KeyboardKeyHandler(_entry);
        }

        private void InputKeyup(object sender, KeyEventArgs e)
        {
            foreach (var handler in _handlers)
            {
                if (!e.Handled)
                    handler.Handle(e);
            }
            
            if (_entry.Submitted)
            {
                _entry.Reset();
            }
            SetInput();
        }

        private void SetInput()
        {
            InputBox.Text = CommandLine();
            InputBox.CaretIndex = InputBox.Text.Length;
        }
        
        private string CommandLine()
        {
            return InputDirectory() + ">" + _entry;
        }

        private string InputDirectory()
        {
            return _currentDirectory.FullName;
        }

        private void InputKeydown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }

    
    

    

    public class Entry
    {
        private string _entry = "";

        public bool Submitted { get; set; }

        private void IfNotEmpty(Func<string, string> action)
        {
            if (_entry.Length > 0)
                _entry = action(_entry);
        }
        
        public void Trim(int characters = 1)
        {
            IfNotEmpty(x => x.Remove(x.Length - characters));
        }

        public void Append(string characters)
        {
            _entry += characters;
        }

        public override string ToString()
        {
            return _entry;
        }

        public void Reset()
        {
            _entry = "";
            Submitted = false;
        }
    }
}
