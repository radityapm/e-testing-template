using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Models.Inventory
{
    public class InventoryModel
    {
        [Column(TypeName = "int")]
        [Required]
        [Key]
        public int Inventory_item_ID { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Item_code { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Item_Desc { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string primary_UOM_code { get; set; }

        [Column(TypeName = "int")]
        public int Organization_id { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Organization_code { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Item_status { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Kfg_Inv_Type_Item { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kfg_Inv_Suhu_Penyimpanan { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kfg_Inv_Precursor_Psycotropic { get; set; }

        [Column(TypeName = "int")]
        public int Shelf_Life { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Het_Kemasan_Primer { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Het_Kemasan_Sekunder_Antara { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Het_Kemasan_Sekunder { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kond_Simpan_Kedap { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kond_Simpan_Hindarkan_Cahaya { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kond_Simpan_Diberi_N2 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Kond_Simpan_Rapat { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Jenis_Sediaan { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Toxic_Beracun { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Environment_Hazard { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Corrosive { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Explosive { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Flamable { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Iritant { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Harmful { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Oxidizing_Chemical { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string B3_Carcinogenic { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Isi_Per_Satuan_Jual { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Isi_Per_Mb { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv1_50 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv2_100 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv3_200 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv4_300 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv5_310 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Gtin_Ntin_Nie_Lv6_400 { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Coding_Set { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Domain_Id { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Id_Kemasan { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Default_Lot_Status { get; set; }

        [Column(TypeName = "int")]
        public int Min_Minmax_Quantity { get; set; }

        [Column(TypeName = "int")]
        public int Max_Minmax_Quantity { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Planning_Make_Buy_Code { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Source_Type { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Planning_Method { get; set; }

        [Column(TypeName = "int")]
        public int Postprocessing { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Format_Md_Ed { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Aktifkan_Serialisasi { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Gmid { get; set; }

        [Column(TypeName = "date")]
        public DateTime Expiry_Date_Nie { get; set; }

        [Column(TypeName = "int")]
        public int Fixed_Lot_Multiplier { get; set; }

        [Column(TypeName = "int")]
        public int Min_Order_Quantity { get; set; }

        [Column(TypeName = "int")]
        public int MyPropMax_Order_Quantityerty { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Kode_Ruah { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Jenis_Toll_In { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Customer_Toll_In { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string Vendor_Toll_Out_Fee { get; set; }

        [Column(TypeName = "varchar(240)")]
        public string User_Item_Type { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Kfg_Inv_Production_Line { get; set; }


    }
}
