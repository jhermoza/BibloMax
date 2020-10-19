using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Hermoza.BibloMax.Integracion.Infraestructura.Autofac
{
    public class RepositoriosModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("Hermoza.BibloMax.Datos"))
            .Where(t => t.Name.EndsWith("Repositorio"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        }

    }
}
