using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistration.Models.ConDb
{
  [Table("Genders", Schema = "dbo")]
  public partial class Gender
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderID
    {
      get;
      set;
    }


    public ICollection<Student> Students { get; set; }

    [Column("Gender")]
    public string Gender1
    {
      get;
      set;
    }
  }
}
