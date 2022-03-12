using Microsoft.Extensions.Options;
using MobileStore.Interface;
using MobileStore.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Data
{
    public class MobileStoreDBContext : IMobileStore
    {
        public readonly IMongoDatabase _db;
        public  MobileStoreDBContext(IOptions<Settings> options)
        {
            var Client = new MongoClient(options.Value.ConnectionString);
            _db = Client.GetDatabase(options.Value.DataBase);
        }
        public IMongoCollection<MobileDeviceEntity> mobiledevicecollection =>
            _db.GetCollection<MobileDeviceEntity>("mobiledevice");

        public void Create(MobileDeviceEntity mobiledeviceData)
        {
          mobiledevicecollection.InsertOne(mobiledeviceData);
        }

        public void Delete(string Name)
        {
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c.Name, Name);
            mobiledevicecollection.DeleteOne(filter);

        }

        public IEnumerable<MobileDeviceEntity> GetAllMobileDevices()
        {
           return mobiledevicecollection.Find(a=>true).ToList();
        }

        public MobileDeviceEntity GetMobileDevDetails(string Name)
        {
            var mobiledevicedetails = mobiledevicecollection.Find(m => m.Name == Name).FirstOrDefault();
            return mobiledevicedetails;
        }

        public void Update(string id, MobileDeviceEntity mobiledeviceData)
        {
          var filter = Builders<MobileDeviceEntity>.Filter.Eq(c=> c.ID , id) ;
            var update = Builders<MobileDeviceEntity>.Update
                .Set("Name", mobiledeviceData.Name)
                .Set("Company", mobiledeviceData.Company)
                .Set("Cost", mobiledeviceData.Cost)
                .Set("Color", mobiledeviceData.color);
            mobiledevicecollection.UpdateOne(filter, update);
        }
    }
}
