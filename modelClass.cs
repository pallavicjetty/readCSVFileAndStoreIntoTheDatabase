using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readCSVFileStoreInDatabase
{
    public class modelClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int passengerid { get; set; }

        public int? survived { get; set; }

        public int? pclass { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(10)]
        public string sex { get; set; }

        public float? age { get; set; }

        public int? sibsp { get; set; }

        public int? parch { get; set; }

        [StringLength(100)]
        public string ticket { get; set; }

        public double? fare { get; set; }

        [StringLength(100)]
        public string cabin { get; set; }

        [StringLength(100)]
        public string embarked { get; set; }
    }
}
