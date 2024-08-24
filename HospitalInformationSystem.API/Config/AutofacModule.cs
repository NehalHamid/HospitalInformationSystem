using Autofac;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Services;
using HospitalInformationSystem.DTO;
namespace HospitalInformationSystem.API.Config
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationDbContext)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BridgeRepository<>)).As(typeof(IBridgeRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(DoctorService).Assembly).InstancePerLifetimeScope();
           
        }
    }
}
