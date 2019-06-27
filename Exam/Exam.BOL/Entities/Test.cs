using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exam.BOL.Entities
{
    [Table("Test")]
    public class Test
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(200)"), StringLength(200,ErrorMessage ="Yazı Başlığı 200 karekterden fazla olamaz"), Display(Name = "Başlık")]
        public string title { get; set; }
        [Column(TypeName = "text"), Display(Name = "Yazı İçeriği")]
        public string content { get; set; }
        [DataType(DataType.DateTime), Display(Name = "Tarih")]
        public DateTime ReleaseDate { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
