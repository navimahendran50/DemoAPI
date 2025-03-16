using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Voucher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(17), Range(1, int.MaxValue), RegularExpression(@"^\d{17}$")]
        public string AccountNo { get; set; } = default!;
        [Required, StringLength(120)]
        public string CustomerName { get; set; } = default!;
        [Required, StringLength(5)]
        public int ActHomeBranch { get; set; } = default!;
        public DateOnly ValueDate { get; set; }
        [NotMapped]
        public string FormattedValueDate => ValueDate.ToString("yy-MMM-yy");
        [StringLength(10)]
        public string? ChequeNo { get; set; }
        [Required, Column(TypeName = "decimal(17,2)")]
        public decimal DebitAmt { get; set; }
        [Required, Column(TypeName = "decimal(17,2)")]
        public decimal CreditAmt { get; set; }
        [Required, StringLength(16)]
        public string UserId { get; set; } = default!;        
        [Required, StringLength(5)]
        public int UserBranch { get; set; }
        [Required, StringLength(9)]
        public string JournalNo { get; set; } = default!;
        [Required, StringLength(3)]
        public string Sys { get; set; } = default!;
        [StringLength(15)]
        public string? TxnDesc { get; set; }
        [StringLength(25)]
        public string? UserIdName { get; set; }
        [StringLength(16)]
        public string? VvrCheckerId { get; set; }
        [StringLength(25)]
        public string? VvrCheckerName { get; set; }
        [StringLength(15)]
        public string? VoucherStatus { get; set; }
        public DateOnly AllocationDate { get; set; }
        [NotMapped]
        public string FormattedAllocationDate => AllocationDate.ToString("yy-MMM-yy");
        [StringLength(1)]
        public int? CheckedStatus { get; set; }
        [StringLength(50)]
        public string? CheckingRemark { get; set; }
        [Required, StringLength(8)]
        public string ValueTime { get; set; } = default!;
        [Required, StringLength(6)]
        public int TxnNo { get; set; }
        public DateOnly ReAllocationDate { get; set; }
        [NotMapped]
        public string FormattedReAllocationDate => ReAllocationDate.ToString("yy-MMM-yy");
        public DateOnly AcceptedDate { get; set; }
        [NotMapped]
        public string FormattedAcceptedDate => AcceptedDate.ToString("yy-MMM-yy");
        public DateOnly VerifiedDate { get; set; }
        [NotMapped]
        public string FormattedVerifiedDate => VerifiedDate.ToString("yy-MMM-yy");
        [StringLength(16)]
        public string? InitialChecker { get; set; }
        [StringLength(16)]
        public string? CbsChecker { get; set; }
        [StringLength(16)]
        public string? CbsSupervisorId { get; set; }
        [StringLength(20)]
        public string? Trickle { get; set; }
    }
}