using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ScheduleController : ApiController
    {
        public IEnumerable<MyObj> Get()
        {
            ICollection<MyObj> myObjs = new List<MyObj>();
            MyObj myObj1 = new MyObj() { skill = "skill1", stage = "stage1", datebegin = "12.03.2019", dateend = "20.09.2019", address = "address1" };
            MyObj myObj2 = new MyObj() { skill = "skill2", stage = "stage2", datebegin = "14.03.2019", dateend = "22.09.2019", address = "address2" };
            myObjs.Add(myObj1);
            myObjs.Add(myObj2);
            return myObjs;
            //return new string[] { "skill", "stage", "12.03.2019", "20.09.2019", "address"};
        }

        public class MyObj
        {
            public string skill;
            public string stage;
            public string datebegin;
            public string dateend;
            public string address;
        }
    }
}
