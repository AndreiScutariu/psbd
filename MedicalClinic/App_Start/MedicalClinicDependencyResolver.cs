﻿/*
 * Autor : Andrei Scutariu
 * Se inregistreaza tipurile intr-un container
 */

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;

namespace MedicalClinic.App_Start
{
    public class MedicalClinicDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public MedicalClinicDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }
    }
}