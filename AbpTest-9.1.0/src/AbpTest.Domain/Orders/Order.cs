using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpTest.Orders
{
    public class Order : AuditedAggregateRoot<Guid>
    {
        public Order(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
