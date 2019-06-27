using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.BOL.Entities
{
    [Table("Option")]
    public class Option
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(200)"), StringLength(200, ErrorMessage = "Cevap 200 karekterden fazla olamaz"), Display(Name = "Cevap")]
        public string answer { get; set; }
        public bool correct { get; set; }
        public int pIndex { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }


    }
}