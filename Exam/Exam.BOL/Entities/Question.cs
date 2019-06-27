using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exam.BOL.Entities
{
    [Table("Question")]
    public class Question
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(250)"), StringLength(200,ErrorMessage ="Soru 250 karekterden fazla olamaz"), Display(Name = "Soru")]
        public string name { get; set; }
        public int TestID { get; set; }
        public Test Test { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
