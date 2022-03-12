using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MobileStore.Models;

namespace MobileStore.Interface
{
    public interface IMobileStore
    {
        IMongoCollection<MobileDeviceEntity> mobiledevicecollection { get; }
        IEnumerable<MobileDeviceEntity> GetAllMobileDevices();
        MobileDeviceEntity GetMobileDevDetails(String Name);
        void Create(MobileDeviceEntity mobiledeviceData);
        void Update(string id, MobileDeviceEntity mobiledeviceData);
        void Delete(String Name);

    }
}
