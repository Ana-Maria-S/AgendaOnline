using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaOnline.ViewModels
{
    public class ToDoItemViewModel
    {
        public long ID { get; set; }

        [StringLength(50), Required]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        public bool Done { get; set; }
        
    }
}