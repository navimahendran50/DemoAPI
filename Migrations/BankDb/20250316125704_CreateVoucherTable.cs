using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations.BankDb
{
    /// <inheritdoc />
    public partial class CreateVoucherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNo = table.Column<string>(type: "TEXT", maxLength: 17, nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    ActHomeBranch = table.Column<int>(type: "INTEGER", maxLength: 5, nullable: false),
                    ValueDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ChequeNo = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    DebitAmt = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    CreditAmt = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    UserBranch = table.Column<int>(type: "INTEGER", maxLength: 5, nullable: false),
                    JournalNo = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Sys = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    TxnDesc = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    UserIdName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    VvrCheckerId = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    VvrCheckerName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    VoucherStatus = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    AllocationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CheckedStatus = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: true),
                    CheckingRemark = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ValueTime = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    TxnNo = table.Column<int>(type: "INTEGER", maxLength: 6, nullable: false),
                    ReAllocationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    AcceptedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    VerifiedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    InitialChecker = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    CbsChecker = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    CbsSupervisorId = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    Trickle = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
