using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Hermoza.BibloMax.Integracion.Infraestructura.Autofac
{
    public class ServiciosModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("Hermoza.BibloMax.Servicios"))
            .Where(t => t.Name.EndsWith("Servicio"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        }

    }
}
