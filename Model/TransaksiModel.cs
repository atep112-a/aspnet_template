using ApiBarang.Model;

namespace ApiUsers.Model
{
    public class TransaksiModel
    {
        public int Id { get; set; }
   

        public int id_users { get; set; }
        public UsersModel User { get; set; }

        public int id_barang { get; set; }
        public BarangModel Barang { get; set; }

        public int jumlah { get; set; }

        public int total {  get; set; }

    }
}
