using System;
using System.Collections.Generic;

public class AllServices
{
   private Dictionary<Type, IService> allServices = new Dictionary<Type, IService>();

   public void Init()
   {
      var resourceService = new ResourceService();
      Register(resourceService);
      
      var storeService = new StoreService(resourceService);
      Register(storeService);
   }

   public T Get<T>()
   {
      var type = typeof(T);
      return (T) allServices[type];
   }

   private void Register<T>(T services) where T : IService
   {
      var type = typeof(T);
      allServices[type] = services;
   }
}
