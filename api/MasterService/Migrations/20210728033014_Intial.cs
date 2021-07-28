using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterService.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Inventory_item_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_code = table.Column<string>(type: "varchar(40)", nullable: true),
                    Item_Desc = table.Column<string>(type: "varchar(250)", nullable: true),
                    primary_UOM_code = table.Column<string>(type: "varchar(25)", nullable: true),
                    Organization_id = table.Column<int>(type: "int", nullable: false),
                    Organization_code = table.Column<string>(type: "varchar(25)", nullable: true),
                    Item_status = table.Column<string>(type: "varchar(10)", nullable: true),
                    Kfg_Inv_Type_Item = table.Column<string>(type: "varchar(50)", nullable: true),
                    Kfg_Inv_Suhu_Penyimpanan = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kfg_Inv_Precursor_Psycotropic = table.Column<string>(type: "varchar(240)", nullable: true),
                    Shelf_Life = table.Column<int>(type: "int", nullable: false),
                    Het_Kemasan_Primer = table.Column<string>(type: "varchar(240)", nullable: true),
                    Het_Kemasan_Sekunder_Antara = table.Column<string>(type: "varchar(240)", nullable: true),
                    Het_Kemasan_Sekunder = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kond_Simpan_Kedap = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kond_Simpan_Hindarkan_Cahaya = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kond_Simpan_Diberi_N2 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kond_Simpan_Rapat = table.Column<string>(type: "varchar(240)", nullable: true),
                    Jenis_Sediaan = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Toxic_Beracun = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Environment_Hazard = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Corrosive = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Explosive = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Flamable = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Iritant = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Harmful = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Oxidizing_Chemical = table.Column<string>(type: "varchar(240)", nullable: true),
                    B3_Carcinogenic = table.Column<string>(type: "varchar(240)", nullable: true),
                    Isi_Per_Satuan_Jual = table.Column<string>(type: "varchar(240)", nullable: true),
                    Isi_Per_Mb = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv1_50 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv2_100 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv3_200 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv4_300 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv5_310 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Gtin_Ntin_Nie_Lv6_400 = table.Column<string>(type: "varchar(240)", nullable: true),
                    Coding_Set = table.Column<string>(type: "varchar(240)", nullable: true),
                    Domain_Id = table.Column<string>(type: "varchar(240)", nullable: true),
                    Id_Kemasan = table.Column<string>(type: "varchar(240)", nullable: true),
                    Default_Lot_Status = table.Column<string>(type: "varchar(30)", nullable: true),
                    Min_Minmax_Quantity = table.Column<int>(type: "int", nullable: false),
                    Max_Minmax_Quantity = table.Column<int>(type: "int", nullable: false),
                    Planning_Make_Buy_Code = table.Column<string>(type: "varchar(30)", nullable: true),
                    Source_Type = table.Column<string>(type: "varchar(30)", nullable: true),
                    Planning_Method = table.Column<string>(type: "varchar(30)", nullable: true),
                    Postprocessing = table.Column<int>(type: "int", nullable: false),
                    Format_Md_Ed = table.Column<string>(type: "varchar(30)", nullable: true),
                    Aktifkan_Serialisasi = table.Column<string>(type: "varchar(25)", nullable: true),
                    Gmid = table.Column<string>(type: "varchar(15)", nullable: true),
                    Expiry_Date_Nie = table.Column<DateTime>(type: "date", nullable: false),
                    Fixed_Lot_Multiplier = table.Column<int>(type: "int", nullable: false),
                    Min_Order_Quantity = table.Column<int>(type: "int", nullable: false),
                    MyPropMax_Order_Quantityerty = table.Column<int>(type: "int", nullable: false),
                    Kode_Ruah = table.Column<string>(type: "varchar(40)", nullable: true),
                    Jenis_Toll_In = table.Column<string>(type: "varchar(240)", nullable: true),
                    Customer_Toll_In = table.Column<string>(type: "varchar(240)", nullable: true),
                    Vendor_Toll_Out_Fee = table.Column<string>(type: "varchar(240)", nullable: true),
                    User_Item_Type = table.Column<string>(type: "varchar(240)", nullable: true),
                    Kfg_Inv_Production_Line = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Inventory_item_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
