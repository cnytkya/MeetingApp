using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models.Entities
{
    public class Meeting
    {
        public int Id { get; set; }

        [Display(Name = "Başlık"), Required]
        public string Title { get; set; }

        [Display(Name = "Başlangıç Zamanı"), Required]
        public DateTime StartTime { get; set; }

        [Display(Name = "Bitiş Zamanı"), Required]
        public DateTime EndTime { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Dosya Yolu")]
        public string DocumentPath { get; set; }
    }
}