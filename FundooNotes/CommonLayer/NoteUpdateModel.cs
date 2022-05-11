using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class NoteUpdateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BgColour { get; set; }

        public bool IsPin { get; set; }
        public bool IsArchieve { get; set; }
        public bool IsReminder { get; set; }
        public bool IsTrash { get; set; }
    }
}
