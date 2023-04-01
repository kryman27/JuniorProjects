using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    internal class Note
    {
        //private List<string> NoteBody { get; set; }
        private string NoteBody { get; set; }
        private string NotePath { get; set; }
        
        public void AddNoteBody(string text)
        {
            NoteBody = text;
        }

        

    }
}
