using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metsys.Bson.Tests
{
    interface ITestClass
    {
         Guid Id { get; set; }
         string Name { get; set; }
    }
}
