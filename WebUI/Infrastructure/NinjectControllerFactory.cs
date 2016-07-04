using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TODO.domain.Abstract;
using TODO.domain.Entities;
using Moq;
using TODO.domain.Concrete;
using TODO.domain.UOF;

namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
           return controllerType == null 
                ? null 
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            /*Mock<ITasksRepository> mock = new Mock<ITasksRepository>();
            mock.Setup(a => a.tasks)
                .Returns(new List<Task>
                {
                    new Task {Name = "Bake as cake",  Priority = TaskPriority.High, Comment = "", Date = DateTime.UtcNow.Date, IsCompleted = true},
                    new Task {Name = "Clean the house",  Priority = TaskPriority.Medium, Comment = "", Date = DateTime.UtcNow.Date, IsCompleted = true}
                });
                */
            ninjectKernel.Bind<ITasksRepository>().To<EFTaskRepository>();        //ToConstant(mock.Object);
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}