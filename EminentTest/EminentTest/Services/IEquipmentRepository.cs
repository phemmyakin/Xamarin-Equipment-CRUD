using EminentTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EminentTest.Services
{
  public interface IEquipmentRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<Equipment> All { get; }
        Equipment Find(string id);
        void Insert(Equipment item);
        void Update(Equipment item);
        void Delete(string id);
    }
}
