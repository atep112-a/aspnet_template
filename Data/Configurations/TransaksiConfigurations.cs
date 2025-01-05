using ApiUsers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiUsers.Data.Configurations
{
    public class TransaksiConfiguration : IEntityTypeConfiguration<TransaksiModel>
    {
        public void Configure(EntityTypeBuilder<TransaksiModel> builder)
        {

            builder.HasOne(t => t.User)
                   .WithMany()
                   .HasForeignKey(t => t.id_users);
            //.OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Barang)
                   .WithMany()
                   .HasForeignKey(t => t.id_barang);
                   //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
