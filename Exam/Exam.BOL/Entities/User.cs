using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exam.BOL.Entities
{
    [Table("User")]
    public class User
    {
        public int ID { get; set; }
        [StringLength(30), Column(TypeName = "Varchar(30)"), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz.")]
        public string username { get; set; }
        [StringLength(20), Column(TypeName = "Varchar(20)"), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string password { get; set; }
    }
}
