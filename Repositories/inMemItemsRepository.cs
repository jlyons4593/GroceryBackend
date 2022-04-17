using CatalogVSCode.Entities;
using System;
using System.Collections.Generic;

namespace CatalogVSCode.Repositories{
    

    public class inMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new(){
            new Item {Id =Guid.NewGuid(), Name= "Milk", Price =2, CreatedDate=DateTimeOffset.UtcNow},
            new Item {Id =Guid.NewGuid(), Name= "Sausages", Price =4, CreatedDate=DateTimeOffset.UtcNow},
            new Item {Id =Guid.NewGuid(), Name= "Bacon", Price =3, CreatedDate=DateTimeOffset.UtcNow},
            new Item {Id =Guid.NewGuid(), Name= "Cheese", Price =2, CreatedDate=DateTimeOffset.UtcNow},
            new Item {Id =Guid.NewGuid(), Name= "Bread", Price =1, CreatedDate=DateTimeOffset.UtcNow}

        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem=> existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}