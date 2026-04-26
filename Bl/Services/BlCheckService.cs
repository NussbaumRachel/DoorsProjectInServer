using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Reflection;

namespace Bl.Services
{
    internal class BlCheckService : IBlCheck
    {


        public IDal Dal;
        public BlCheckService(IDal dal)
        {
            this.Dal = dal;
        }
        public void Create(BlCheck item)
        {
          Dal.checks.Create(convertFromBlChecksToDalChecks(item));
        }

        public  bool Delete(BlCheck item)
        {
        Dal.checks.Delete(convertFromBlChecksToDalChecks(item));return true;
        }
        public bool DeleteById(int id)
        {
            Dal.checks.Delete(id); return true;
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public BlCheck Get(int id)
        {
            return convertFromDalChecksToBlChecks(Dal.checks.Get(id).Result) ;
        }

               public async Task<List<BlCheck>> GetAll()
        {
            List<BlCheck> blCheckList = new List<BlCheck>();

            // משיג את סוג המחלקה של BlDoor
            Type typeDoor = typeof(BlDoor);
            Type typeFrame = typeof(BlDoorFrame);
            // מקבל את כל המאפיינים (properties) במחלקה BlDoor
            PropertyInfo[] propertiesDoors = typeDoor.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] propertiesFrames = typeFrame.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            int i = 0;
            string[] properties = new string[propertiesDoors.Length + propertiesFrames.Length];
            foreach (var property in propertiesDoors)
            {
                var propertyName = property.Name.ToString();
                propertyName = propertyName.Replace("k__BackingField", "");
                propertyName = char.ToLower(propertyName[0]) + propertyName.Substring(1);
                properties[i++] = propertyName;
            }
            foreach (var property in propertiesFrames)
            {
                if(propertiesDoors.FirstOrDefault(p => p.Name == property.Name) == null)
                {
                    var propertyName = property.Name.ToString();
                    propertyName = propertyName.Replace("k__BackingField", "");
                    propertyName = char.ToLower(propertyName[0]) + propertyName.Substring(1);
                    properties[i++] = propertyName;
                }
                    
            }
            // עבור כל מאפיין ב-BlDoor
            foreach (var property in properties)
            {
                if(property != null) { 
                // בודק אם המאפיין אינו קשור ל-backfield (k__BackingField)
                
                    // משיג את כל הערכים המוגבלים עבור מאפיין זה מתוך DAL
                    var allChecks = await Dal.checks.GetAll();
                   
                    var blCheck = new BlCheck
                    {
                        //Id = 0,
                        Key = property,  // שם המאפיין ב-BlDoor יהיה ה-Key
                        Values = new List<Check>()
                    };                   // חיפוש כל הערכים המוגבלים מתוך ה-DAL שמאוחסנים תחת המפתח המתאים
                    List<Check> possibleValuesForProperty = allChecks.Where(c => c.Key == property).Select(c => c).ToList();

                    // שומרים את הערכים המוגבלים ב-Values
                    blCheck.Values.AddRange(possibleValuesForProperty);

                    // מוסיפים את BlCheck לרשימה
                    blCheckList.Add(blCheck);
                }
            }

            return blCheckList;
        }
        public async Task<List<BlCheck>> GetByKey(String key)
        {
            List<BlCheck> l = new List<BlCheck>() { };
            Dal.checks.GetAll().Result.FindAll(c => c.Key == key).ForEach(c => l.Add(convertFromDalChecksToBlChecks(c)));
            return l;
        }
        
        public BlCheck convertFromDalChecksToBlChecks(Check c)
        {
            BlCheck newblCheck = new BlCheck()
            {
                //Id = c.Id,
                Key = c.Key,
                Values = Dal.checks.GetAll().Result.FindAll(ch => ch.Key == c.Key).Select(ch => ch).ToList()
            };

            return newblCheck;
        }
        public Check convertFromBlChecksToDalChecks(BlCheck c)
        {
            Check newCheck = new Check();
            //newCheck.Id = c.Id;
            newCheck.Key = c.Key;
            newCheck.Value = c.Values[0].Value;
            return newCheck;
        }
        public Check convertFromBlChecksToDalChecks(BlCheck c,int ind)
        {
            Check newCheck = new Check();
            //newCheck.Id = c.Id;
            newCheck.Key = c.Key;
            newCheck.Value = c.Values[ind].Value;
            return newCheck;
        }
        public void Update(BlCheck item)
        {
            throw new NotImplementedException();
        }
    }
}
