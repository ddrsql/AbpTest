using System;
using System.Collections.Generic;
using System.Text;

namespace AbpTest.Books.Dtos
{
    public class BookOutput
    {
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? LastModifierId { get; set; }
    }
}
