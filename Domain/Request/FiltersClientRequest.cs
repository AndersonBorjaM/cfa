using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class FiltersClientRequest
    {
        public FiltersClientRequest() { }

        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyOrderBy { get; set; }
        public bool AscendingOrderBy { get; set; } = true;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
