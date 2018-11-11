using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardstone.Web.Models.StoreViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
    }
}
