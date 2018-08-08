using System.Data.Entity.ModelConfiguration;

namespace Domain.GEN
{
   public class MesasureMap: EntityTypeConfiguration<MeasureEquivalence>
    {

        public MesasureMap()
        {
            HasRequired(o => o.MeasureMaster)
                .WithMany(m => m.MeasureMasters)
                .HasForeignKey(m => m.MeasureMasterId);

            HasRequired(o => o.MeasureSlave)
                .WithMany(m => m.MeasureSlaves)
                .HasForeignKey(m => m.MeasureSlaveId);
        }
    }
}
