using DemoSystem2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSystem2.BLL
{
    [DataObject]
    public class DemoController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
       

            public List<Person> ListPeople()
            {
                using (var context = new DemoContext())
                {
                    return context.People.ToList();
                }
            }
        

    }
}
