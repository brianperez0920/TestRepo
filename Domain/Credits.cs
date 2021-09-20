using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public partial class Credits
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [MaxLength(3)]
        public int CreditScore { get; set; }
    }
}
