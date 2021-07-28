﻿// <auto-generated />
using System;
using MasterService.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasterService.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20210728033014_Intial")]
    partial class Intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MasterService.Models.Inventory.InventoryModel", b =>
                {
                    b.Property<int>("Inventory_item_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aktifkan_Serialisasi")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("B3_Carcinogenic")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Corrosive")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Environment_Hazard")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Explosive")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Flamable")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Harmful")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Iritant")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Oxidizing_Chemical")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("B3_Toxic_Beracun")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Coding_Set")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Customer_Toll_In")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Default_Lot_Status")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Domain_Id")
                        .HasColumnType("varchar(240)");

                    b.Property<DateTime>("Expiry_Date_Nie")
                        .HasColumnType("date");

                    b.Property<int>("Fixed_Lot_Multiplier")
                        .HasColumnType("int");

                    b.Property<string>("Format_Md_Ed")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Gmid")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv1_50")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv2_100")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv3_200")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv4_300")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv5_310")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Gtin_Ntin_Nie_Lv6_400")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Het_Kemasan_Primer")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Het_Kemasan_Sekunder")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Het_Kemasan_Sekunder_Antara")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Id_Kemasan")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Isi_Per_Mb")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Isi_Per_Satuan_Jual")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Item_Desc")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Item_code")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Item_status")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Jenis_Sediaan")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Jenis_Toll_In")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kfg_Inv_Precursor_Psycotropic")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kfg_Inv_Production_Line")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Kfg_Inv_Suhu_Penyimpanan")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kfg_Inv_Type_Item")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Kode_Ruah")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Kond_Simpan_Diberi_N2")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kond_Simpan_Hindarkan_Cahaya")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kond_Simpan_Kedap")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Kond_Simpan_Rapat")
                        .HasColumnType("varchar(240)");

                    b.Property<int>("Max_Minmax_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Min_Minmax_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Min_Order_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("MyPropMax_Order_Quantityerty")
                        .HasColumnType("int");

                    b.Property<string>("Organization_code")
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Organization_id")
                        .HasColumnType("int");

                    b.Property<string>("Planning_Make_Buy_Code")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Planning_Method")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Postprocessing")
                        .HasColumnType("int");

                    b.Property<int>("Shelf_Life")
                        .HasColumnType("int");

                    b.Property<string>("Source_Type")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("User_Item_Type")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Vendor_Toll_Out_Fee")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("primary_UOM_code")
                        .HasColumnType("varchar(25)");

                    b.HasKey("Inventory_item_ID");

                    b.ToTable("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
