using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_List.Objects
{
    public class Items
    {
        public List<Item> itemList { get; set; }

        public int GetMaxId()
        {
            return itemList.Select(x => x.Id).Max();
        }
    }
}
