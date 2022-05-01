using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Menu.Models
{
    public class MenuSession
    {
        //pages 332-333 for info on wrapper class
        private const string FoodsKey = "myfoods";      //Key name corresponding to a List<Food> of the users favorite foods 
        private const string CountKey = "foodcount";    //The name of the property corresponding to the # food in order
        private const string CatKey = "cat";            //Key Corresponding to current category
        private const string NameKey = "name"; // for SetName() and GetName()


        private ISession session { get; set; }

        //when an interface is used as a return type in c#, this means that
        //instances of classes derived from that interface can be returned
        //thus any class implementing Isession can be returned by the set method here
        //likewise, any class implementing Isession can be passed into the get method here.

        public MenuSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyFoods(List<Food> foods)
        {
            session.SetObject(FoodsKey, foods);
            session.SetInt32(CountKey, foods.Count);
        }

        public List<Food> GetMyFood() =>
            session.GetObject<List<Food>>(FoodsKey) ?? new List<Food>();

        public int? GetMyFoodCount() => session.GetInt32(CountKey);

        public void SetName(string userName = "[UserName]")
        {
            session.SetString(NameKey, userName);
            //Namekey is a constant that we're using ffor the "name" of this session variable
            //userName is the value that we're setting at the present time
        }

        public string GetName() => session.GetString(NameKey);



        //public void SetActiveCat(string category) =>
            //session.SetString(CatKey, category);

        public string GetActiveCat() => session.GetString(CatKey);

        public void RemoveMyFoods()
        {
            session.Remove(FoodsKey);
            session.Remove(CountKey);
        }
    }
}
