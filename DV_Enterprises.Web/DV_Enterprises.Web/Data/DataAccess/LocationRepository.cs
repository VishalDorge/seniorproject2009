//using System;
//using System.Collections.Generic;
//using System.Linq;
//using DV_Enterprises.Web.Data.DataAccess.Interface;
//using DV_Enterprises.Web.Data.Domain;
//using StructureMap;

//namespace DV_Enterprises.Web.Data.DataAccess
//{
//    [Pluggable("Default")]
//    public class LocationRepository : ILocationRepository
//    {
//        private Connection _conn;

//        public LocationRepository()
//        {
//            _conn =  new Connection();
//        }

//        public List<Address> GetLocations()
//        {
//            List<Address> result;
//            using (var dc = _conn.GetContext())
//            {
//                IEnumerable<Address> locations = dc.Locations;
//                result = locations.ToList();
//            }
//            return result;
//        }

//        public Address GetLocation(int locationId)
//        {
//            var result = new Address();
//            using (var dc = _conn.GetContext())
//            {
//                result = dc.Locations.Where(l => l.LocationId == locationId).SingleOrDefault();
//            }
//            return result;
//        }


//        public Address GetLocation(Greenhouse greenhouse)
//        {
//            var result = new Address();
//            using (var dc = _conn.GetContext())
//            {
//                result = dc.Locations.Where(l => l.Greenhouses.Contains(greenhouse)).SingleOrDefault();
//            }
//            return result;
//        }

//        public int SaveLocation(Address location)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                var dbLocation = dc.Locations.Where(l => l.LocationId == location.LocationId).SingleOrDefault();
//                var isNew = false;
//                if (dbLocation == null)
//                {
//                    dbLocation = new Address();
//                    isNew = true;
//                }
//                dbLocation.AddressLine1 = location.AddressLine1;
//                dbLocation.AddressLine2 = location.AddressLine2;
//                dbLocation.City = location.City;
//                dbLocation.State = location.State;
//                dbLocation.Zip = location.Zip;
//                dbLocation.Country = location.Country;
//                if (isNew)
//                    dc.Locations.InsertOnSubmit(dbLocation);
//                dc.SubmitChanges();
//                location.LocationId = dbLocation.LocationId;
//            }
//            return location.LocationId;
//        }

//        public void DeleteLocation(Address location)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                dc.Locations.Attach(location, true);
//                dc.Locations.DeleteOnSubmit(location);
//                dc.SubmitChanges();
//            }
//        }

//        public void DeleteLocation(int locationId)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                var location = dc.Locations.Where(l => l.LocationId == locationId).FirstOrDefault();
//                dc.Locations.DeleteOnSubmit(location);
//                dc.SubmitChanges();
//            }
//        }
//    }
//}