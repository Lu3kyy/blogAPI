using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;
using blogAPI.Services.Context;

namespace blogAPI.Services

{
    //AddBlogItems
    // GetAllBlogItems
    // GetBlogItemByCategory
    // GetBlogItemsByTags
    // GetBlogItemsByDate
    // GetPublishedBlogItems
    // UpdateBlogItems
    // DeleteBlogItems
    // GetUserById
    public class BlogItemService
    {
        private readonly DataContext _context;
        public BlogItemService(DataContext context)
        {
            _context = context;
        }
        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            bool result;

            _context.Add(newBlogItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

        public bool DeleteBlogItems(BlogItemModel blogToDelete)
        {
            _context.Update(blogToDelete);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        {
            return _context.BlogInfo.Where(item => item.Category == category);
        }

         public IEnumerable<BlogItemModel> GetPublishedBlogItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _context.BlogInfo.Where(item => item.Date == date);
        }

        public List<BlogItemModel> GetItemsByTag(string tag)
        {
           List<BlogItemModel> AllBlogsWithTag = new List<BlogItemModel>();
           var allItems = GetAllBlogItems().ToList();
           for (int i = 0; i < allItems.Count; i++)
           {
           BlogItemModel Item = allItems[i];
           var itemArr = Item.Tags.Split(",");

           //second for loop will iterate for array and add tag to database so we can compare it to the tag we are looking for and break out of it
           for (int j = 0; j < itemArr.Length; j++)
                {
                    if (itemArr[j] == tag)
                    {
                        AllBlogsWithTag.Add(Item);
                        break;
                    }
                }

            }
            return AllBlogsWithTag;
        }

        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
            _context.Update(blogUpdate);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.IsPublished);
        }
    }
}