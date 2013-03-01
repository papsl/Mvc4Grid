using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Mvc4Grid.Models.Repositories;

namespace Mvc4Grid.Models.Helpers
{
    public class MvcControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return Activator.CreateInstance(controllerType, new FakeComputersRepository()) as IController;
        }
    }
}
