﻿// <auto-generated />
using System;
using DemoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoAPI.Migrations.BankDb
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20250316125704_CreateVoucherTable")]
    partial class CreateVoucherTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("DemoAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DemoAPI.Models.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("AcceptedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("TEXT");

                    b.Property<int>("ActHomeBranch")
                        .HasMaxLength(5)
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("AllocationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CbsChecker")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("CbsSupervisorId")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<int?>("CheckedStatus")
                        .HasMaxLength(1)
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckingRemark")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ChequeNo")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CreditAmt")
                        .HasColumnType("decimal(17,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DebitAmt")
                        .HasColumnType("decimal(17,2)");

                    b.Property<string>("InitialChecker")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("JournalNo")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ReAllocationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sys")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.Property<string>("Trickle")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("TxnDesc")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("TxnNo")
                        .HasMaxLength(6)
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserBranch")
                        .HasMaxLength(5)
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserIdName")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ValueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueTime")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("VerifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VoucherStatus")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("VvrCheckerId")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("VvrCheckerName")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
